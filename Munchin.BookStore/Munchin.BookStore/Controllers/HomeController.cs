using Microsoft.AspNetCore.Mvc;

namespace Munchin.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index( )
        {
            return View();
        }

        [Route( "about-us/{name:alpha:minlength(5)}" )]
        public ViewResult AboutUs( string name )
        {
            return View();
        }
        public ViewResult ContactUs( )
        {
            return View();
        }
    }
}
