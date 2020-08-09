namespace InformationTypes
{
    /// <summary>
    /// Defines a student.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Student name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Student surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Check the equality of this student
        /// instance and other object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !(this.GetType().Equals(obj.GetType())))
                return false;

            var student = (Student)obj;

            return this.Name.Equals(student.Name)
                && this.Surname.Equals(student.Surname);
        }

        /// <summary>
        /// Returns a hash-code for a Student object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Surname.GetHashCode();
        }

        /// <summary>
        /// Returns a formatted string filled with
        /// Student data.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Surname} {Name}";
        }
    }
}
