using Microsoft.AspNetCore.Mvc.Rendering;

namespace BancoMusica.Models
{
    public class GeneroMusicaViewModel
    {
        public List<Musica> Musicas { get; set; }
        public SelectList? Genero { get; set; }
        public string? GeneroMusica { get; set; }
        public string? SearchString { get; set; }

    }
}
