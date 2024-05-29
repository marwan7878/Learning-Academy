using MVCDemo.Models;

namespace MVCDemo.Repositories
{
	public class DepartmentMemoryRepository : IDepartmentRepository
	{
		List<Department> context;
		public DepartmentMemoryRepository()
		{
			ID = Guid.NewGuid();
			context = new List<Department>
			{
				new Department {Id=0, Name="CS" ,ManagerName="Maro",Location="Cairo",Employees=new List<Employee> {}},
				new Department {Id=1, Name="CS" ,ManagerName="Maro",Location="Cairo",Employees=new List<Employee> {}},
				new Department {Id=2, Name="CS" ,ManagerName="Maro",Location="Cairo",Employees=new List<Employee> {}},
				new Department {Id=3, Name="CS" ,ManagerName="Maro",Location="Cairo",Employees=new List<Employee> {}}
			};
		}
		public Guid ID { get; set; }

		public List<Department> GetAll()
		{
			return context;
		}

		public Department GetById(int id)
		{
			return context.FirstOrDefault(d => d.Id == id);
		}

		public void Insert(Department department)
		{
			context.Add(department);
		}
		
		public void Delete(int id)
		{
			throw new NotImplementedException();
		}
		public void Update(Department department)
		{
			throw new NotImplementedException();
		}
		public void save()
		{
			throw new NotImplementedException();

		}

		
	}
}
