
using Filters.Infrastructure;
using System;
using System.Web.Mvc;

[HandleError]
public class HomeController : Controller
    
   
{
   // [CustomAction]
   // [CustomAuth(false)]
   // [Authorize(Users = null, Roles = "admin")]
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Index(string Дата, string Заказчик, string Телефон, string Услуга, bool? Допуслуги, int? Отзыв)
    {
        if (Отзыв.HasValue)
        {
            ViewBag.Дата = Дата;
            ViewBag.Заказчик = Заказчик;
            ViewBag.Телефон = Телефон;
            ViewBag.Услуга = Услуга;
            ViewBag.Допуслуги = Допуслуги;
            ViewBag.Отзыв = Отзыв.Value;
            return View("Result");
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")]
    public string RangeTest(int id)
    {
        if (id > 100)
        {
            return String.Format("The id value is: {0}", id);
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }

}


