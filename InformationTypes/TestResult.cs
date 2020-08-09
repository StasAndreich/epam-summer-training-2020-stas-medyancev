using System;

namespace InformationTypes
{
    /// <summary>
    /// Defines a student test results class.
    /// </summary>
    public class TestResult : IComparable<TestResult>
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
        /// Compares one object to another.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(TestResult obj)
        {
            // If other is not a valid object reference, 
            // this instance is greater.
            if (obj == null) return 1;
            // If objects are equal they are same.
            if (this.Equals(obj)) return 0;

            // Compare test names.
            if (!this.TestName.Equals(obj.TestName))
                return this.TestName.CompareTo(obj.TestName);
            // Compare tests by pass date.
            if (!this.Date.Equals(obj.Date))
                return this.Date.CompareTo(obj.Date);
            // Compare tests by mark.
            return this.Mark.CompareTo(obj.Mark);
        }

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

        /// <summary>
        /// Define the is greater than operator.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator >(TestResult lhs, TestResult rhs)
        {
            return lhs.CompareTo(rhs) >= 1;
        }

        /// <summary>
        /// Define the is less than operator.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator <(TestResult lhs, TestResult rhs)
        {
            return lhs.CompareTo(rhs) <= -1;
        }

        /// <summary>
        /// Define the is greater than or equal to operator.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator >=(TestResult lhs, TestResult rhs)
        {
            return lhs.CompareTo(rhs) >= 0;
        }

        /// <summary>
        /// Define the is less than or equal to operator.
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator <=(TestResult lhs, TestResult rhs)
        {
            return lhs.CompareTo(rhs) <= 0;
        }
    }
}
