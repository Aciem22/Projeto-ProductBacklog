using BancoMusica.Repositorio;
using Microsoft.AspNetCore.Mvc;
using BancoMusica.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BancoMusica.Controllers
{
    public class UsuarioController : Controller
    {


        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio) 
            {
                _usuarioRepositorio = usuarioRepositorio;
            }

        public IActionResult Index()
        {
            List<UsuarioModel> usuario = _usuarioRepositorio.BuscarTodos();

            return View(usuario);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction("Index", "Login");
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
