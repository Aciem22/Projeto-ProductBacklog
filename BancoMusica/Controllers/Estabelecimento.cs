using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace BancoMusica.Controllers
{
    public class Estabelecimento : Controller
    {
        //GET:/HelloWorld/
        public IActionResult Index()
        {
            return View();
        }
        //GET: /Helloworld/Welcome/
        public IActionResult Welcome(string name, int ID = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["ID"] = ID;
            return View();
        }

    }
}
