using BancoMusica.Data;
using BancoMusica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BancoMusica.Data;
using BancoMusica.Models;
using DocumentFormat.OpenXml.InkML;

namespace BancoMusica.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly BancoMusicaContext _context;

        public UsuarioRepositorio(BancoMusicaContext bancoContext)
        {
            this._context = bancoContext;
        }


        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Nome.ToUpper() == login.ToUpper());
        }

        public UsuarioModel Apagar(int Id)
        {
            UsuarioModel usuarioDB = BuscarPorID(Id);
            if (usuarioDB == null) throw new Exception("Houve um erro na deleção");

            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();
            return usuarioDB;
        }

        public UsuarioModel BuscarPorID(int Id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == Id);
        }

       

        public List<UsuarioModel> BuscarTodos()
        {
            return _context.Usuarios.ToList();
        }
    }
}
