using OfficeOpenXml;
using System;
using System.Linq;

namespace BusinessLogicUsingLinq
{
    /// <summary>
    /// Defines all methods for creation xlsx files 
    /// filled with session info.
    /// </summary>
    public static class XlsxCreator
    {
        /// <summary>
        /// Creates an xlsx file that holds session results
        /// by each university group.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="results"></param>
        public static void CreateXlsxResultsFile(string filePath,
                                                 IQueryable<SessionResults> results)
        {
            var resultsByGroup = from result in results
                                 group result by result.groupName;

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

        /// <summary>
        /// Creates an xlsx file that holds session statistics
        /// by each university group.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="stats"></param>
        public static void CreateXlsxStatisticsFile(string filePath,
                                                 IEnumerable<SessionStatistics> stats)
        {
            using (var excelPackage = new ExcelPackage())
            {
                // Set excel document props.
                excelPackage.Workbook.Properties.Title = "SesionStatistics";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                // Create a worksheet.
                var worksheet = excelPackage.Workbook.Worksheets.
                    Add("Statistics");
                // Insert data into the worksheet.
                InsertStatisticsIntoWorksheet(worksheet, stats);

                var file = new FileInfo(filePath);
                excelPackage.SaveAs(file);
            }
        }

        /// <summary>
        /// Creates an xlsx file that holds contributable students
        /// by each university group.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="students"></param>
        public static void CreateXlsxContributableStudentsFile(string filePath,
                                                 IEnumerable<ContributableStudents> students)
        {
            using (var excelPackage = new ExcelPackage())
            {
                // Set excel document props.
                excelPackage.Workbook.Properties.Title = "ContributableStudents";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                // Get students by group.
                var resultsByGroup = from result in students
                                     group result by result.groupName;

                foreach (var item in resultsByGroup)
                {
                    // Create a worksheet.
                    var worksheet = excelPackage.Workbook.Worksheets.
                        Add($"{item.Key}");

                    // Insert data into the worksheet.
                    InsertContributableStudentsIntoWorksheet(worksheet,
                                                             item.ToList());
                }

                var file = new FileInfo(filePath);
                excelPackage.SaveAs(file);
            }
        }

        private static void InsertResultsIntoWorksheet(ExcelWorksheet worksheet,
                                                       IEnumerable<SessionResults> groupResultList)
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

        private static void InsertStatisticsIntoWorksheet(ExcelWorksheet worksheet,
                                                       IEnumerable<SessionStatistics> statList)
        {
            worksheet.Cells["A1"].Value = "Group";
            worksheet.Cells["B1"].Value = "Min mark";
            worksheet.Cells["C1"].Value = "Avg mark";
            worksheet.Cells["D1"].Value = "Max mark";

            // Cell number.
            var i = 2;
            foreach (var item in statList)
            {
                worksheet.Cells["A" + i].Value = item.groupName;
                worksheet.Cells["B" + i].Value = item.minMark;
                worksheet.Cells["C" + i].Value = item.avgMark;
                worksheet.Cells["D" + i].Value = item.maxMark;
                i++;
            }
        }

        private static void InsertContributableStudentsIntoWorksheet(ExcelWorksheet worksheet,
                                                       IEnumerable<ContributableStudents> students)
        {
            worksheet.Cells["A1"].Value = "Name";
            worksheet.Cells["B1"].Value = "Last name";
            worksheet.Cells["C1"].Value = "Patronym";
            worksheet.Cells["D1"].Value = "Mark";

            // Cell number.
            var i = 2;
            foreach (var item in students)
            {
                worksheet.Cells["A" + i].Value = item.name;
                worksheet.Cells["B" + i].Value = item.lastName;
                worksheet.Cells["C" + i].Value = item.patronym;
                worksheet.Cells["D" + i].Value = item.mark;
                i++;
            }
        }
    }
}
