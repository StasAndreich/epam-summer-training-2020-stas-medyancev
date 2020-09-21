using BusinessLogicUsingLinq.DTOs;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BusinessLogicUsingLinq
{
    /// <summary>
    /// Defines all methods for creation xlsx files 
    /// filled with session info.
    /// </summary>
    public static class XlsxCreator
    {
        #region Xlsx files creation
        /// <summary>
        /// Creates an xlsx file that holds specialty statistics.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="stats"></param>
        public static void CreateXlsxSpecialtyStatistics(string filePath,
                                                 IQueryable<SpecialtyStatistics> stats)
        {
            var avgBySpecName = from stat in stats
                                group stat by stat.SpecialtyName;

            using (var excelPackage = new ExcelPackage())
            {
                // Set excel document props.
                excelPackage.Workbook.Properties.Title = "SpecialtyStatistics";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                // Create a worksheet.
                var worksheet = excelPackage.Workbook.Worksheets.
                    Add("AvgMarkBySpecialty");
                // Insert data into the worksheet.
                InsertSpecialtyStatisticsIntoWorksheet(worksheet, stats.ToList());

                var file = new FileInfo(filePath);
                excelPackage.SaveAs(file);
            }
        }

        /// <summary>
        /// Creates an xlsx file that holds examiner statistics.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="stats"></param>
        public static void CreateXlsxExaminerStatistics(string filePath,
                                                 IQueryable<ExaminerStatistics> stats)
        {
            var avgByExaminerName = from stat in stats
                                    group stat by stat.ExaminerName;

            using (var excelPackage = new ExcelPackage())
            {
                // Set excel document props.
                excelPackage.Workbook.Properties.Title = "ExaminerStatistics";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                // Create a worksheet.
                var worksheet = excelPackage.Workbook.Worksheets.
                    Add("AvgMarkByExaminer");
                // Insert data into the worksheet.
                InsertExaminerStatisticsIntoWorksheet(worksheet, stats.ToList());

                var file = new FileInfo(filePath);
                excelPackage.SaveAs(file);
            }
        }

        /// <summary>
        /// Creates an xlsx file that holds session results
        /// by each university group.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="results"></param>
        public static void CreateXlsxResults(string filePath,
                                                 IQueryable<SessionResults> results)
        {
            var resultsByGroup = from result in results
                                 group result by result.GroupName;

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
        public static void CreateXlsxStatistics(string filePath,
                                                 IQueryable<SessionStatistics> stats)
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
        public static void CreateXlsxContributableStudents(string filePath,
                                                 IQueryable<ContributableStudents> students)
        {
            using (var excelPackage = new ExcelPackage())
            {
                // Set excel document props.
                excelPackage.Workbook.Properties.Title = "ContributableStudents";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                // Get students by group.
                var resultsByGroup = from result in students
                                     group result by result.GroupName;

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
        #endregion


        #region Insertion helpers
        private static void InsertSpecialtyStatisticsIntoWorksheet(ExcelWorksheet worksheet,
                                                       IEnumerable<SpecialtyStatistics> stats)
        {
            worksheet.Cells["A1"].Value = "Specialty name";
            worksheet.Cells["B1"].Value = "Avg mark";

            // Cell number.
            var i = 2;
            foreach (var item in stats)
            {
                worksheet.Cells["A" + i].Value = item.SpecialtyName;
                worksheet.Cells["B" + i].Value = item.AvgMark;
                i++;
            }
        }

        private static void InsertExaminerStatisticsIntoWorksheet(ExcelWorksheet worksheet,
                                                       IEnumerable<ExaminerStatistics> stats)
        {
            worksheet.Cells["A1"].Value = "Examiner surname";
            worksheet.Cells["B1"].Value = "Avg mark";

            // Cell number.
            var i = 2;
            foreach (var item in stats)
            {
                worksheet.Cells["A" + i].Value = item.ExaminerName;
                worksheet.Cells["B" + i].Value = item.AvgMark;
                i++;
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
                worksheet.Cells["A" + i].Value = item.StudentName;
                worksheet.Cells["B" + i].Value = item.StudentSurname;
                worksheet.Cells["C" + i].Value = item.StudentPatronym;
                worksheet.Cells["D" + i].Value = item.SubjectName;
                worksheet.Cells["E" + i].Value = item.Result;
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
                worksheet.Cells["A" + i].Value = item.GroupName;
                worksheet.Cells["B" + i].Value = item.MinMark;
                worksheet.Cells["C" + i].Value = item.AvgMark;
                worksheet.Cells["D" + i].Value = item.MaxMark;
                i++;
            }
        }

        private static void InsertContributableStudentsIntoWorksheet(ExcelWorksheet worksheet,
                                                       IEnumerable<ContributableStudents> students)
        {
            worksheet.Cells["A1"].Value = "Name";
            worksheet.Cells["B1"].Value = "Surname";
            worksheet.Cells["C1"].Value = "Patronym";
            worksheet.Cells["D1"].Value = "Mark";

            // Cell number.
            var i = 2;
            foreach (var item in students)
            {
                worksheet.Cells["A" + i].Value = item.Name;
                worksheet.Cells["B" + i].Value = item.Surname;
                worksheet.Cells["C" + i].Value = item.Patronym;
                worksheet.Cells["D" + i].Value = item.Mark;
                i++;
            }
        } 
        #endregion
    }
}
