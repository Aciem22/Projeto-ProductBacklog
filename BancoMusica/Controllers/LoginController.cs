using System.Security.Policy;
using BancoMusica.Models;
using BancoMusica.Repositorio;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;

namespace BancoMusica.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {

                   UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Nome);

                    if(usuario!=null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Musicas");
                        }

                        TempData["MensagemErro"] = "Senha inválida";
					}

                    TempData["MensagemErro"] = "Usuario invalido";
                }

                return View("Index");

            }catch (Exception ex) {

                TempData["MensagemErro"] = ex;
                return RedirectToAction("Index");
            
            }
        }
    }
}
