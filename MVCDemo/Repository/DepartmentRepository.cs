using MVCDemo.Models;

namespace MVCDemo.Repositories
{
	public class DepartmentRepository : IDepartmentRepository
	{
		DBEntity context;
		public Guid ID { get; set; }

		public DepartmentRepository(DBEntity _context) 
		{
			context = _context;
			ID = Guid.NewGuid();
		}

		public List<Department> GetAll()
		{
			return context.Department.ToList();
		}

		public Department GetById(int id)
		{
			return context.Department.FirstOrDefault(d=> d.Id == id);
		}

		public void Insert(Department department)
		{
			context.Department.Add(department);
		}
		public void Update(Department department)
		{
			context.Department.Update(department);	
		}
		public void Delete(int id)
		{
			context.Department.Remove(GetById(id));
		}
		public void save()
		{
			context.SaveChanges();
		}

	}
}
