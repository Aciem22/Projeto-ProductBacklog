using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BancoMusica.Data;
using BancoMusica.Models;
using DocumentFormat.OpenXml.Bibliography;

namespace BancoMusica.Controllers
{
    public class MusicasController : Controller
    {
        private readonly BancoMusicaContext _context;

        public MusicasController(BancoMusicaContext context)
        {
            _context = context;
        }

        // GET: Musicas
        //public async Task<IActionResult> Index()
        //{
            //Inicio
            public async Task<IActionResult> Index(string GeneroMusica, string searchString, int? pagenumber)
            {
                
                if(_context.Musica == null)
                {
                    return Problem("ERRO de entidade é nulo");
                }
            //inicio
            IQueryable<string> genreQuery = from m in _context.Musica
                                            orderby m.Genre
                                            select m.Genre;

                //O LINQ (Language-Integrated Query) fornece recursos de consulta no nível da linguagem e uma API de função
                //de ordem superior para C# e Visual Basic, que permitem escrever código declarativo expressivo.

                var musicas = from m in _context.Musica
                              select m;


                if (!String.IsNullOrEmpty(searchString))
                {
                    musicas = musicas.Where(s => s.Title!.Contains(searchString));
                }

            if (!String.IsNullOrEmpty(GeneroMusica))
            {
                musicas = musicas.Where(x => x.Genre == GeneroMusica);
            }

            var GeneroMusicaVM = new GeneroMusicaViewModel
            {
                Genero = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Musicas = await musicas.ToListAsync()
            };

                return View(GeneroMusicaVM);

            }

        public async Task<IActionResult> Indexee(string GeneroMusica, string searchString)
        {

            if (_context.Musica == null)
            {
                return Problem("ERRO de entidade é nulo");
            }
            //inicio
            IQueryable<string> genreQuery = from m in _context.Musica
                                            orderby m.Genre
                                            select m.Genre;

            //O LINQ (Language-Integrated Query) fornece recursos de consulta no nível da linguagem e uma API de função
            //de ordem superior para C# e Visual Basic, que permitem escrever código declarativo expressivo.

            var musicas = from m in _context.Musica
                          select m;


            if (!String.IsNullOrEmpty(searchString))
            {
                musicas = musicas.Where(s => s.Title!.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(GeneroMusica))
            {
                musicas = musicas.Where(x => x.Genre == GeneroMusica);
            }

            var GeneroMusicaVM = new GeneroMusicaViewModel
            {
                Genero = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Musicas = await musicas.ToListAsync()
            };

            return View(GeneroMusicaVM);

        }

        //FIM


        /*
              return _context.Musica != null ? 
                          View(await _context.Musica.ToListAsync()) :
                          Problem("Entity set 'BancoMusicaContext.Musica'  is null.");
        }*/

        // GET: Musicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Musica == null)
            {
                return NotFound();
            }

            var musica = await _context.Musica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musica == null)
            {
                return NotFound();
            }

            return View(musica);
        }

        // GET: Musicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Musicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Musica musica)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(musica);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
            }
            catch (DbUpdateException /* ex*/)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
            "Try again, and if the problem persists " +
            "see your system administrator.");
            }
            return View(musica);
        }
        // GET: Musicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Musica == null)
            {
                return NotFound();
            }

            var musica = await _context.Musica.FindAsync(id);
            if (musica == null)
            {
                return NotFound();
            }
            return View(musica);
        }

        // POST: Musicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var musicaToUpdate = await _context.Musica.FirstOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync<Musica>(
                musicaToUpdate,"",
                s => s.Title, s =>s.Descricao, s=> s.Genre, s=> s.ReleaseDate))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(musicaToUpdate);
        }

        // GET: Musicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Musica == null)
            {
                return NotFound();
            }

            var musica = await _context.Musica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (musica == null)
            {
                return NotFound();
            }

            return View(musica);
        }

        // POST: Musicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Musica == null)
            {
                return Problem("Entity set 'BancoMusicaContext.Musica'  is null.");
            }
            var musica = await _context.Musica.FindAsync(id);
            if (musica != null)
            {
                _context.Musica.Remove(musica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusicaExists(int id)
        {
          return (_context.Musica?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
