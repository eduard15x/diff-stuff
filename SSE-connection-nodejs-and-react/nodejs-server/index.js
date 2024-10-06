const express = require("express");
const multer = require("multer");
const fs = require("fs");
const path = require("path");

const app = express();
const upload = multer({ dest: "uploads/" });

let clients = []; // Store clients connected via SSE

// Endpoint for SSE connection to stream progress
app.get("/invoice-progress", (req, res) => {
  console.log("test");
  res.setHeader("Content-Type", "text/event-stream");
  res.setHeader("Cache-Control", "no-cache");
  res.setHeader("Connection", "keep-alive");

  clients.push(res);

  req.on("close", () => {
    clients = clients.filter((client) => client !== res);
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
  const files = req.files;
  let processedCount = 0;

  for (const file of files) {
    try {
      // Simulate processing delay
      await new Promise((resolve) => setTimeout(resolve, 2000));

      // Mock data extraction (you would use your AI extraction service here)
      const extractedData = { invoiceNumber: "12345", totalAmount: "$1000" };

      processedCount++;
      const progress = (processedCount / files.length) * 100;

      // Send progress update to clients
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
