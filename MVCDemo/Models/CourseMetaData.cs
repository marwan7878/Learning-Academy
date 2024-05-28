using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class CourseMetaData
    {
        public int Id { get; set; }
        [MinLength(2)]
        [MaxLength(25)]
        [UniquePerDepartment]
        public string Name { get; set; }
        [Range(50, 100)]
        public string Degree { get; set; }

        [Remote("TestMinDegree", "Course",
            ErrorMessage = "Min Degree must be less than Degree and more than 0"
            , AdditionalFields = "Degree")]
        public string MinDegree { get; set; }

        [ForeignKey("Department")]
        [Remote("TestID", "Course",
            ErrorMessage = "Please Select any Department")]
        public int Dept_Id { get; set; }
        public Department? Department { get; set; }
    }
}
