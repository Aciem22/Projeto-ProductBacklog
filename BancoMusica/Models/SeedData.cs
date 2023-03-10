using BancoMusica.Data;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BancoMusica.Models;

    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BancoMusicaContext(serviceProvider.GetRequiredService<DbContextOptions<BancoMusicaContext>>()))
            {
                if (context.Musica.Any())
                {
                    return;
                }
            try
            {
                context.Musica.AddRange(
                    new Musica
                    {
                        Title = "Vizzen & Protolizard - Heaven Knows",
                        ReleaseDate = DateTime.Parse("2023-02-28"),
                        Genre = "Eletrônica",
                        Video = "https://open.spotify.com/embed/track/36JG5eKqKzTkWXvhf8BHEk?utm_source=generator"
                    }
                    );
            }

            catch (Exception ex)
            {
                return;
            }
                context.SaveChanges();
            }
        }

    }

