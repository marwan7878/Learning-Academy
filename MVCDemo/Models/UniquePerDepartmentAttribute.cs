using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class UniquePerDepartmentAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DBEntity context = new DBEntity();
            Course courseFromReq = validationContext.ObjectInstance as Course;
            Course course = context.Course.
                FirstOrDefault(e => e.Name == value.ToString() && courseFromReq.Dept_Id == e.Dept_Id);

            if (course == null)
            {
                return ValidationResult.Success;
            }
            else if(courseFromReq.Id != 0 && course == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name already Found");
        }
       
    }
}
