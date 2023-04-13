using BancoMusica.Data;
using BancoMusica.Enum;
using Microsoft.EntityFrameworkCore;
using System;

namespace BancoMusica.Models
{
    public class UsuarioModel
    {

  
        public int Id { get; set; }

        public string Nome { get; set; }

        public PerfilEnum Perfil { get; set; }

        public string Senha { get; set; }

        public bool SenhaValida(string Senha)
        {
            return this.Senha == Senha;
        }

    }
}

