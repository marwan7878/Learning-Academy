using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department? Department { get; set; }

    }
}
