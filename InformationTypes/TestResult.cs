using System;

namespace InformationTypes
{
    /// <summary>
    /// Defines a student test results class.
    /// </summary>
    public class TestResult
    {
        /// <summary>
        /// Student.
        /// </summary>
        public Student Student { get; set; }
        /// <summary>
        /// Test name.
        /// </summary>
        public string TestName { get; set; }
        /// <summary>
        /// Pass date.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Test mark.
        /// </summary>
        public int Mark { get; set; }

        /// <summary>
        /// Check the equality of this test result
        /// instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var testResult = (TestResult)obj;

            return this.Student.Equals(testResult.Student)
                && this.TestName.Equals(testResult.TestName)
                && this.Date.Equals(testResult.Date)
                && this.Mark.Equals(testResult.Mark);
        }

        /// <summary>
        /// Returns a hash-code for a TestResult object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Student.GetHashCode() ^
                TestName.GetHashCode() ^
                Date.GetHashCode() ^
                Mark.GetHashCode();
        }

        /// <summary>
        /// Returns a formatted string filled with
        /// TestResult data.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Test passed by: {Student};\n" +
                $"Subject: {TestName};\n" +
                $"Date: {Date};\n" +
                $"Mark: {Mark}.";
        }
    }
}
