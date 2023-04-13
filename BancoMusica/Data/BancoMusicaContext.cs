using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BancoMusica.Models;

namespace BancoMusica.Data
{
    public class BancoMusicaContext : DbContext
    {
        public BancoMusicaContext (DbContextOptions<BancoMusicaContext> options)
            : base(options)
        {
        }

        public DbSet<BancoMusica.Models.Musica> Musica { get; set; } = default!;
        public DbSet<BancoMusica.Models.LoginModel> Login { get; set; } = default!;
        public DbSet<Models.UsuarioModel> Usuarios { get; set; }
    }
}
