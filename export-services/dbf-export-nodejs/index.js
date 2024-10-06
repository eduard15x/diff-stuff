import { DBFFile } from "dbffile";
import path from "path";

async function batchWrite(fileName = "data.dbf") {
  let fieldDescriptors = [
    { name: "Name", type: "C", size: 255 }, // Character type with a maximum length of 50
    { name: "Age", type: "N", size: 20, decimalPlaces: 0 }, // Numeric type (Age) with size and decimal places
    { name: "City", type: "C", size: 255 }, // Character type for City
    { name: "isMajor", type: "L", size: 1 }, // Logical type (boolean)
  ];

  // Create the records based on the new dataset
  let records = [
    { Name: "John", Age: 18, City: "New York", isMajor: false },
    { Name: "Anna", Age: 22, City: "London", isMajor: true },
    { Name: "Mike", Age: 32, City: "Chicago", isMajor: true },
  ];

  let dbf = await DBFFile.create(fileName, fieldDescriptors);
  console.log("DBF file created.");

  //   const formattedRecords = records.map((record) => ({
  //     ...record,
  //     isMajor: record.isMajor ? "T" : "F", // Convert boolean to logical
  //   }));

  //   await dbf.appendRecords(records);
  await dbf.appendRecords(records); // this is custom

  console.log(`${records.length} records added.`);
  console.log(
    `DBF file has been saved to ${path.join(process.cwd(), fileName)}`
  );
}

await batchWrite("data.dbf");
