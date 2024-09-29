import fs from "fs/promises"; // Use fs/promises for async/await
import { PDFDocument } from "pdf-lib";
import path from "path";

async function modifyPdf(inputPdfPathValue, outputPdfPathValue) {
  try {
    // Relative path to the input PDF file
    const absolutePdfPath = path.join(process.cwd(), inputPdfPathValue);

    // Read the PDF from the file system
    const formPdfBytes = await fs.readFile(absolutePdfPath);

    // Load the PDF document
    const pdfDoc = await PDFDocument.load(formPdfBytes);

    // Get the form containing all the fields
    const form = pdfDoc.getForm();

    // Fill the form's fields
    // form.getTextField("Furnizor").setText("Some Text Furnizor");
    form.getTextField("text1").setText("Some Text text1");
    form.getTextField("text2").setText("Some Text text2");
    form.getTextField("text3").setText("Some Text text3");

    // Flatten the form's fields
    form.flatten();

    // Serialize the PDFDocument to bytes (a Uint8Array)
    const pdfBytes = await pdfDoc.save();

    // Save the modified PDF back to the file system
    const outputPdfPath = path.join(process.cwd(), outputPdfPathValue);
    await fs.writeFile(outputPdfPath, pdfBytes);

    console.log(`PDF modified and saved to: ${outputPdfPath}`);
  } catch (error) {
    console.error("Error processing PDF:", error);
  }
}

// Example usage:
const dataset = [
  { placeholder: "Furnizor", newValue: "TEST REPLACE FURNIZOR" },
  { placeholder: "IBAN", newValue: "TEST REPLACE IBAN" },
];

const pdfPath = "F-1-24SOLO-fillable2.pdf"; // Path to the template PDF
const outputPath = "output2.pdf"; // Path to save the modified PDF

// Call the function to modify the PDF
await modifyPdf(pdfPath, outputPath);

// replacePlaceholdersInPDF(pdfPath, dataset, outputPath);
