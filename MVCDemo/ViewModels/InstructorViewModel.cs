namespace MVCDemo.ViewModels
{
    public class InstructorViewModel
    {
        public InstructorViewModel() { }
        public InstructorViewModel(string Name , string Image , int Salary , string Address ) 
        {
            this.Name = Name;
            this.Image = Image;
            this.Salary = Salary;
            this.Address = Address;
           
        }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Course_Name { get; set; }
        public string Department_Name { get; set; }

    }
}
