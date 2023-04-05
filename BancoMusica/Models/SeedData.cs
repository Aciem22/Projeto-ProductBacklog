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
          
              
            }
        }

    }

