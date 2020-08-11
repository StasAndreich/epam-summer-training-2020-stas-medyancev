using System;

namespace InformationTypes
{
    /// <summary>
    /// Defines a student.
    /// </summary>
    [Serializable]
    public class Student
    {
        /// <summary>
        /// Inits a student.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        public Student(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        private string name;
        private string surname;

        /// <summary>
        /// Student name.
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value;
        }
        /// <summary>
        /// Student surname.
        /// </summary>
        public string Surname
        {
            get => surname;
            set => surname = value;
        }

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

            return this.Name.ToUpper().Equals(student.Name.ToUpper())
                && this.Surname.ToUpper().Equals(student.Surname.ToUpper());
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
