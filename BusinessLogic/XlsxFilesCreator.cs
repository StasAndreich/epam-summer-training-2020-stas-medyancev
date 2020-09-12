using OfficeOpenXml;
using System;
using System.IO;

namespace BusinessLogic
{
    /// <summary>
    /// Defines all methods for creation xlsx files 
    /// filled with session info.
    /// </summary>
    public static class XlsxFilesCreator
    {
        /// <summary>
        /// Creates an xlsx file that holds session results
        /// by each university group.
        /// </summary>
        /// <param name="filePath"></param>
        public static void CreateXslxResultsFile(string filePath)
        {
            using (var excelPackage = new ExcelPackage())
            {
                // Set excel document props.
                excelPackage.Workbook.Properties.Title = "SesionResults";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                // Create the worksheet.
                var worksheet = excelPackage.Workbook.Worksheets.Add("Group: ");
                worksheet.Cells["A1"].Value = "some info";

                var file = new FileInfo(filePath);
                excelPackage.SaveAs(file);
            }
        }
    }
}
