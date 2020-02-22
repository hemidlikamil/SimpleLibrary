using System.Web;
using System.Web.Mvc;

namespace SimpleLibrary.CustomAuth
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return ((SessionProvider.Current == null || SessionProvider.Current.IsInRole(Roles)) && SessionProvider.IsLoggedIn);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            RedirectToRouteResult routeData = null;

            if (!SessionProvider.IsLoggedIn)
            {
                routeData = new RedirectToRouteResult
                (new System.Web.Routing.RouteValueDictionary
                (new
                {
                    controller = "Account",
                    action = "Login",
                    returnUrl = filterContext.HttpContext.Request.Url?.AbsolutePath ?? ""
                }
                ));
                filterContext.Result = routeData;
            }
            //else
            //{
            //    routeData = new RedirectToRouteResult
            //    (new System.Web.Routing.RouteValueDictionary
            //    (new
            //    {
            //        controller = "Error",
            //        action = "AccessDenied"
            //    }
            //    ));
            //}

        }

    }
}