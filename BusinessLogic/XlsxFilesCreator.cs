using OfficeOpenXml;
using System;
using System.Linq;
using System.Collections.Generic;
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
        /// <param name="results"></param>
        public static void CreateXslxResultsFile(string filePath, 
                                                 IEnumerable<SessionResults> results)
        {
            var resultsByGroup = from result in results
                                 group result by result.groupName;
                                 //select new { }
            using (var excelPackage = new ExcelPackage())
            {
                // Set excel document props.
                excelPackage.Workbook.Properties.Title = "SesionExamResults";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                foreach (var groupResult in resultsByGroup)
                {
                    // Create a worksheet.
                    var worksheet = excelPackage.Workbook.Worksheets.
                        Add($"{groupResult.Key}");
                    // Insert data into the worksheet.
                    InsertResultsIntoWorksheet(worksheet, groupResult.ToList());
                }

                var file = new FileInfo(filePath);                                      
                excelPackage.SaveAs(file);
            }
        }

        private static void InsertResultsIntoWorksheet(ExcelWorksheet worksheet,
                                                       List<SessionResults> groupResultList)
        {
            worksheet.Cells["A1"].Value = "Name";
            worksheet.Cells["B1"].Value = "Surname";
            worksheet.Cells["C1"].Value = "Patronym";
            worksheet.Cells["D1"].Value = "Subject";
            worksheet.Cells["E1"].Value = "Result";

            // Cell number.
            var i = 2;
            foreach (var item in groupResultList)
            {
                worksheet.Cells["A" + i].Value = item.studentFirstName;
                worksheet.Cells["B" + i].Value = item.studentLastname;
                worksheet.Cells["C" + i].Value = item.studentPatronymic;
                worksheet.Cells["D" + i].Value = item.subjectName;
                worksheet.Cells["E" + i].Value = item.result;
                i++;
            }
        }
    }
}
