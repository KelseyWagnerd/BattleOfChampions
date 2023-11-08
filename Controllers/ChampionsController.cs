using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BattleOfChampions.Data;
using BattleOfChampions.Models;
using Microsoft.AspNetCore.Authorization;

namespace BattleOfChampions.Controllers
{
    public class ChampionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChampionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Champions
        public async Task<IActionResult> Index()
        {
              return _context.Champion != null ? 
                          View(await _context.Champion.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Champion'  is null.");
        }

        // GET: Champions/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return _context.Champion != null ?
                        View() :
                        Problem("Entity set 'ApplicationDbContext.Champion'  is null.");
        }

        // POST: Champions/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return _context.Champion != null ?
                        View("Index", await _context.Champion
                        .Where(c => c.Name.Contains(SearchPhrase) || c.Bio.Contains(SearchPhrase))
                        .ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Champion'  is null.");
        }

        // GET: Champions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Champion == null)
            {
                return NotFound();
            }

            var champion = await _context.Champion
                .FirstOrDefaultAsync(m => m.ChampionID == id);
            if (champion == null)
            {
                return NotFound();
            }

            return View(champion);
        }

        // GET: Champions/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Champions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChampionID,Name,Bio,Attack,Defense,Speed,Health")] Champion champion)
        {
            if (ModelState.IsValid)
            {
                champion.ChampionID = Guid.NewGuid();
                _context.Add(champion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(champion);
        }

        // GET: Champions/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Champion == null)
            {
                return NotFound();
            }

            var champion = await _context.Champion.FindAsync(id);
            if (champion == null)
            {
                return NotFound();
            }
            return View(champion);
        }

        // POST: Champions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ChampionID,Name,Bio,Attack,Defense,Speed,Health")] Champion champion)
        {
            if (id != champion.ChampionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(champion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChampionExists(champion.ChampionID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(champion);
        }

        // GET: Champions/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Champion == null)
            {
                return NotFound();
            }

            var champion = await _context.Champion
                .FirstOrDefaultAsync(m => m.ChampionID == id);
            if (champion == null)
            {
                return NotFound();
            }

            return View(champion);
        }



        // POST: Champions/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Champion == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Champion'  is null.");
            }
            var champion = await _context.Champion.FindAsync(id);
            if (champion != null)
            {
                _context.Champion.Remove(champion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChampionExists(Guid id)
        {
          return (_context.Champion?.Any(e => e.ChampionID == id)).GetValueOrDefault();
        }
    }
}
