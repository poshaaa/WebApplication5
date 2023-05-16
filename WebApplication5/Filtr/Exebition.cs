using System;
using System.Web.Mvc;

public class CustomArgumentOutOfRangeExceptionFilterAttribute : FilterAttribute, IExceptionFilter
{
    public void OnException(ExceptionContext filterContext)
    {
        if (filterContext.Exception is ArgumentOutOfRangeException)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "ArgumentOutOfRange",
                ViewData = filterContext.Controller.ViewData,
                TempData = filterContext.Controller.TempData
            };
            filterContext.ExceptionHandled = true;
        }
    }
}