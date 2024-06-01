using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
	public class Account
	{
		public int Id { get; set; }

		[MaxLength(100)]
		public string UserName { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
