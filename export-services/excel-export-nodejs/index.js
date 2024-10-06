const XLSX = require("xlsx");

function exportToExcel(data, fileName = "data.xlsx") {
  // Create a new workbook
  const workbook = XLSX.utils.book_new();

  // Convert the data to a worksheet
  const worksheet = XLSX.utils.json_to_sheet(data);

  // Append the worksheet to the workbook
  XLSX.utils.book_append_sheet(workbook, worksheet, "Sheet1");

  // Write the workbook to a file
  XLSX.writeFile(workbook, fileName);
}

// Example usage
const data = [
  { Name: "John", Age: 30, City: "New York" },
  { Name: "Anna", Age: 22, City: "London" },
  { Name: "Mike", Age: 32, City: "Chicago" },
];

exportToExcel(data, "myData.xlsx");
