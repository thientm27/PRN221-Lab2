using System.ComponentModel.DataAnnotations;

namespace Lab2RazorCRUD.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public string Description { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }
        public Course Course { get; set; }
        public Student student { get; set; }

    }
}
