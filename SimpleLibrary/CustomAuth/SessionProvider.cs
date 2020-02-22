using SimpleLibrary.Models;
using System.Web;

namespace SimpleLibrary.CustomAuth
{
    public class SessionProvider
    {
        public static User Current => HttpContext.Current.Session["USER"] as User;

        public static bool IsLoggedIn => Current != null;

        public static void Login(User user)
        {
            HttpContext.Current.Session.Add("USER", user);
        }

        public static void Logout()
        {
            HttpContext.Current.Session.Remove("USER");
        }
    }
}