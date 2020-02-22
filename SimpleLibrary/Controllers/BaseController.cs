using System.Web.Mvc;
using SimpleLibrary.CustomAuth;

namespace SimpleLibrary.Controllers
{
    [CustomAuthorize]
    public class BaseController : Controller
    {

    }
}