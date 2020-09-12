using OfficeOpenXml;
using System;
using System.IO;

namespace BusinessLogic
{
    public static class XlsxFilesCreator
    {
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
