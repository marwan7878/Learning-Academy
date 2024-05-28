using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Models
{
    public class CourseResult
    {
        public int Id { get; set; }
        public float Degree { get; set; }

        [ForeignKey("Course")]
        public int Course_Id { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Trainee")]
        public int Trainee_Id { get; set; }
        public Trainee Trainee { get; set; }
    }
}
