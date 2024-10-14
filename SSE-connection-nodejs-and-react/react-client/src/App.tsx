import { useEffect, useState } from "react";
import "./App.css";
interface ExtractedData {
  invoiceNumber: string;
  totalAmount: string;
}
function App() {
  const [progress, setProgress] = useState(0);

  // const [extractedData, setExtractedData] = useState({});

  const [extractedData, setExtractedData] = useState<
    Record<string, ExtractedData>
  >({});

  const [imagePreviews, setImagePreviews] = useState<Record<string, string>>(
    {}
  );
  // const [imagePreviews, setImagePreviews] = useState({});
  const [totalFiles, setTotalFiles] = useState<number>(0);
  const [localNr, setLocalNr] = useState<number>(0);

  useEffect(() => {
    console.log("Extracted Data Updated: ", extractedData);
  }, [extractedData]);
  const handleFileSelect = async (e: React.ChangeEvent<HTMLInputElement>) => {
    const files = Array.from(e.target.files ?? []);
    setTotalFiles(files.length);

    // Open SSE connection to receive progress updates
    const eventSource = new EventSource(
      "http://localhost:3001/invoice-progress"
    );

    eventSource.onopen = () => {
      console.log("SSE connection opened.");
    };

    eventSource.onerror = (err) => {
      console.error("SSE connection error:", err);
    };

    console.log("TEST 1");
    eventSource.onmessage = (event) => {
      const { fileName, data, progress } = JSON.parse(event.data);
      // Update the progress and extracted data
      setExtractedData((prev) => ({
        ...prev,
        [fileName]: data,
      }));

      setProgress(progress);

      console.log(JSON.parse(event.data));

      // Close connection when all files are processed
      if (progress >= 100) {
        eventSource.close();
        console.log("SSE connection closed. eventSource.close");
      }
    };

    // Preview images before upload
    files.forEach((file) => {
      const reader = new FileReader();
      reader.onload = (e) => {
        const previewUrl = e.target?.result as string;
        setImagePreviews((prev) => ({ ...prev, [file.name]: previewUrl }));
      };
      reader.readAsDataURL(file); // Convert file to data URL for image preview
    });

    // Create FormData to send all files at once
    const formData = new FormData();
    files.forEach((file) => formData.append("files", file));

    // Send all files to the backend
    await fetch("http://localhost:3001/upload-invoices", {
      method: "POST",
      body: formData,
    });
  };
  return (
    <div>
      <div>
        <h1>{localNr}</h1>
        <button onClick={() => setLocalNr(localNr + 1)}>increase</button>
        <label>Upload Files</label>
        <input type="file" multiple onChange={handleFileSelect} />
        <div>Total files number: {totalFiles}</div>
      </div>
      <div>Progress: {progress} %</div>
      <pre>{JSON.stringify(extractedData, null, 2)}</pre>
    </div>
  );
}

export default App;
