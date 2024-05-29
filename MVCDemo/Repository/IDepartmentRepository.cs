using MVCDemo.Models;

namespace MVCDemo.Repositories
{
	public interface IDepartmentRepository
	{
		Guid ID { get; set; }
		List<Department> GetAll();
		Department GetById(int id);
		void Insert(Department department);
		void Update(Department department);
		void Delete(int id);
		void save();

	}
}
