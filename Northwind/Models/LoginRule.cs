using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
//using System.Web.Http.Filters;
using System.Web.Mvc;

namespace Northwind
{
    public class LoginRule : ActionFilterAttribute
    {
        void LoginCheck(HttpContext context)
        {
            if (context.Session["employee"] == null)
                context.Response.Redirect("/Manager/Login");
        }
       
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RouteData.GetRequiredString("controller").Equals("Manager", StringComparison.CurrentCultureIgnoreCase)
            && filterContext.RouteData.GetRequiredString("action").Equals("Login", StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }
            LoginCheck(HttpContext.Current);
            
        }

    }
}