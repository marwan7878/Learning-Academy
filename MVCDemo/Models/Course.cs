using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;


namespace MVCDemo.Models
{
    [ModelMetadataType(typeof(CourseMetaData))]
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public string MinDegree { get; set; }
        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        public Department? Department { get; set; }

    }
}
