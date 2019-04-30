using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UserId"] == null || Session["UserId"].ToString() == null)
            {
                filterContext.Result =
                    new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { area = "", controller = "Login", action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}