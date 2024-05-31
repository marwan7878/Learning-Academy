using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCDemo.Filters
{
	public class HandleErrorAttribute : Attribute, IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			//ContentResult contentResult = new ContentResult();
			//contentResult.Content = "Maro is not here";
			//context.Result = contentResult;
			ViewResult viewResult = new ViewResult();
			viewResult.ViewName = "Error";
			context.Result = viewResult;
		}
	}
}
