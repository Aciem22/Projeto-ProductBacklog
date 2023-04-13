using BancoMusica.Models;
using System.Collections.Generic;


namespace BancoMusica.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string Nome);

        List<UsuarioModel> BuscarTodos();
        UsuarioModel BuscarPorID(int Id);
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Apagar(int Id);
        
    }
}
