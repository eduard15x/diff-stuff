const fs = require("fs");
const path = require("path");

function exportToCSV(data, fileName = "data.csv") {
  // Check if data is not empty
  if (!data || data.length === 0) {
    console.error("No data provided for CSV export");
    return;
  }

  // Extract the headers
  const headers = Object.keys(data[0]);

  // Convert the headers to CSV format
  const csvRows = [headers.join(",")];

  // Convert each row of data to CSV format
  for (const row of data) {
    const values = headers.map((header) => {
      // Escape any quotes in the data
      const escaped = String(row[header]).replace(/"/g, '""');
      // Wrap each value in double quotes
      return `"${escaped}"`;
    });
    csvRows.push(values.join(","));
  }

  // Combine all rows into a single CSV string
  const csvContent = csvRows.join("\n");

  // Define the file path
  const filePath = path.join(__dirname, fileName);

  // Write the CSV string to a file
  fs.writeFileSync(filePath, csvContent, "utf8");

  console.log(`CSV file has been saved to ${filePath}`);
}

// Example usage
const data = [
  { Name: "John", Age: 30, City: "New York" },
  { Name: "Anna", Age: 22, City: "London" },
  { Name: "Mike", Age: 32, City: "Chicago" },
];

exportToCSV(data, "myData.csv");
