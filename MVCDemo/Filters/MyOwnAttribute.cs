using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCDemo.Filters
{
	public class MyOwnAttribute : Attribute, IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext context)
		{
			throw new NotImplementedException();
		}
		

		public void OnActionExecuting(ActionExecutingContext context)
		{
			throw new NotImplementedException();
		}
	}
}
