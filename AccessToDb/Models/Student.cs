using System;

namespace AccessToDb.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public int GroupID { get; set; }
    }
}
