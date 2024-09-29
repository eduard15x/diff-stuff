// Import the required module
import { writeFile } from "fs/promises";

/**
 * Function to generate SQL INSERT queries and save them to a .sql file
 * @param {Array} data - The dataset to be exported
 * @param {String} tableName - The name of the SQL table
 * @param {String} fileName - The name of the SQL file to be saved
 */
async function exportToSQL(data, tableName, fileName = "data.sql") {
  try {
    // Map over the data to generate INSERT queries
    const queries = data
      .map((record) => {
        // Construct the columns and values
        const columns = Object.keys(record).join(", ");
        const values = Object.values(record)
          .map((value) => {
            // Handle string values (escape single quotes)
            if (typeof value === "string") {
              return `'${value.replace(/'/g, "''")}'`;
            }
            // Handle boolean values
            if (typeof value === "boolean") {
              return value ? "TRUE" : "FALSE";
            }
            // Return numeric values as is
            return value;
          })
          .join(", ");

        // Return the complete SQL INSERT statement
        return `INSERT INTO ${tableName} (${columns}) VALUES (${values});`;
      })
      .join("\n"); // Join all queries with new lines

    // Write the SQL queries to a .sql file
    await writeFile(fileName, queries, "utf-8");
    console.log(`Data successfully exported to ${fileName}`);
  } catch (error) {
    console.error("An error occurred while exporting to SQL:", error);
  }
}

/**
 * Function to generate a single SQL INSERT query and save it to a .sql file
 * @param {Array} data - The dataset to be exported
 * @param {String} tableName - The name of the SQL table
 * @param {String} fileName - The name of the SQL file to be saved
 */
async function exportToSQLWithValuesConcatenated(
  data,
  tableName,
  fileName = "data.sql"
) {
  try {
    // Construct the column names from the first record
    const columns = Object.keys(data[0]).join(", ");

    // Map over the data to generate the values for each record
    const values = data
      .map((record) => {
        // Format the values for each record
        const formattedValues = Object.values(record)
          .map((value) => {
            // Handle string values (escape single quotes)
            if (typeof value === "string") {
              return `'${value.replace(/'/g, "''")}'`;
            }
            // Handle boolean values
            if (typeof value === "boolean") {
              return value ? "TRUE" : "FALSE";
            }
            // Return numeric values as is
            return value;
          })
          .join(", ");

        // Return the formatted value set for each row
        return `(${formattedValues})`;
      })
      .join(",\n");

    // Create the complete SQL INSERT statement
    const query = `INSERT INTO ${tableName} (${columns})\nVALUES\n${values};`;

    // Write the SQL query to a .sql file
    await writeFile(fileName, query, "utf-8");
    console.log(`Data successfully exported to ${fileName}`);
  } catch (error) {
    console.error("An error occurred while exporting to SQL:", error);
  }
}

// Example usage
const records = [
  { Name: "John", Age: 18, City: "New York", isMajor: false },
  { Name: "Anna", Age: 22, City: "London", isMajor: true },
  { Name: "Mike", Age: 32, City: "Chicago", isMajor: true },
];

const tableName = "YourTableName"; // Replace with your actual table name

// Call the function to export data to a SQL file
await exportToSQL(records, tableName, "insert_queries.sql");
await exportToSQLWithValuesConcatenated(
  records,
  tableName,
  "insert_queries_concatenated.sql"
);
