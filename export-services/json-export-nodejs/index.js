// Import the required 'fs' module for file system operations
import { writeFile } from "fs/promises";

// The dataset to export
const records = [
  { Name: "John", Age: 18, City: "New York", isMajor: false },
  { Name: "Anna", Age: 22, City: "London", isMajor: true },
  { Name: "Mike", Age: 32, City: "Chicago", isMajor: true },
];

/**
 * Function to export data to a JSON file
 * @param {Array} data - The dataset to be exported
 * @param {String} fileName - The name of the JSON file to export
 */
async function exportToJSON(data, fileName = "data.json") {
  try {
    // Convert the data to JSON format (pretty-printed)
    const jsonData = JSON.stringify(data, null, 2);

    // Write the JSON data to a file
    await writeFile(fileName, jsonData, "utf-8");
    console.log(`Data successfully exported to ${fileName}`);
  } catch (error) {
    console.error("An error occurred while exporting data:", error);
  }
}

// Call the export function with the dataset and desired file name
await exportToJSON(records, "records.json");
