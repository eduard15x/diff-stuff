// Import the required modules
import { create } from "xmlbuilder2";
import { writeFile } from "fs/promises";

// The dataset to be exported
const records = [
  { Name: "John", Age: 18, City: "New York", isMajor: false },
  { Name: "Anna", Age: 22, City: "London", isMajor: true },
  { Name: "Mike", Age: 32, City: "Chicago", isMajor: true },
];

/**
 * Function to export data to XML format and save it as a file
 * @param {Array} data - The dataset to be exported
 * @param {String} fileName - The name of the XML file to save
 */
async function exportToXML(
  data,
  fileName = "data.xml",
  xmlRecordsName = "Records",
  xmlSingleRecordName = "Name"
) {
  try {
    // Create the root XML document
    const root = create({ version: "1.0" }).ele(xmlRecordsName);

    // Loop through each record and add it to the XML document
    data.forEach((record) => {
      const recordEle = root.ele(xmlSingleRecordName);
      Object.keys(record).forEach((key) => {
        recordEle.ele(key).txt(record[key]);
      });
    });

    // Convert the XML document to a string
    const xmlContent = root.end({ prettyPrint: true });

    // Write the XML content to a file
    await writeFile(fileName, xmlContent, "utf-8");
    console.log(`Data successfully exported to ${fileName}`);
  } catch (error) {
    console.error("An error occurred while exporting data:", error);
  }
}

// Call the export function with the dataset and desired file name
await exportToXML(records, "records.xml", "List", "Item");
