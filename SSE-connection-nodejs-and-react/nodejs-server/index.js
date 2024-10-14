const express = require("express");
const multer = require("multer");
const cors = require("cors");
const app = express();
const upload = multer({ dest: "uploads/" });

app.use(cors());

let clients = []; // Store clients connected via SSE

// Endpoint for SSE connection to stream progress
app.get("/invoice-progress", (req, res) => {
  res.setHeader("Content-Type", "text/event-stream");
  res.setHeader("Cache-Control", "no-cache");
  res.setHeader("Connection", "keep-alive");
  res.flushHeaders(); // Ensure headers are sent immediately

  clients.push(res);
  console.log("Client connected. Total clients:", clients.length);

  // Clean up when connection closes
  req.on("close", () => {
    clients = clients.filter((client) => client !== res);
    console.log("Client disconnected. Total clients:", clients.length);
  });
});

// Function to broadcast progress to clients
const sendProgressUpdate = (fileName, data, progress) => {
  clients.forEach((client) => {
    client.write(`data: ${JSON.stringify({ fileName, data, progress })}\n\n`);
  });
};

// Upload endpoint (handles multiple files)
app.post("/upload-invoices", upload.array("files"), async (req, res) => {
  console.log("upload-invoice");
  const files = req.files;
  let processedCount = 0;
  let progress = 0;

  // Wait until at least one SSE client is connected before processing files
  const waitForClient = () =>
    new Promise((resolve) => {
      const checkClients = setInterval(() => {
        if (clients.length > 0) {
          clearInterval(checkClients);
          resolve();
        }
      }, 100); // Check every 100ms if a client is connected
    });

  await waitForClient(); // Wait for an SSE connection

  // Process files after ensuring at least one client is connected
  for (const file of files) {
    try {
      sendProgressUpdate(file.originalname, {}, progress); // Initial progress
      await new Promise((resolve) => setTimeout(resolve, 200)); // Simulated processing delay

      const extractedData = { invoiceNumber: "12345", totalAmount: "$1000" };
      processedCount++;
      progress = (processedCount / files.length) * 100;

      sendProgressUpdate(file.originalname, extractedData, progress);
    } catch (err) {
      console.error(err);
    }
  }

  res
    .status(200)
    .json({ message: "All files uploaded and processing started" });
});

app.listen(3001, () => {
  console.log("Server is running on http://localhost:3001");
});
