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
using Microsoft.IdentityModel.Tokens;
using BattleOfChampions.Infrastructure;
using BattleOfChampions.dto;
using BattleOfChampions.AbstractClasses;

namespace BattleOfChampions.Controllers
{
    public class ChampionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        Utilities _utilities;
        private readonly IChampionLogic _championLogic;
        public ChampionsController(ApplicationDbContext context,Utilities utility,IChampionLogic championLogic)
        {
            _context = context;
            _utilities= utility;
            _championLogic=championLogic;
        }

        // GET: Champions
        public async Task<IActionResult> Index()
        {
            var champions=await _championLogic.GetChampions();
              return _context.Champion != null ? 
                          View(champions) :
                          Problem("Entity set 'ApplicationDbContext.Champion'  is null.");
        }
  

        // GET: Champions/ShowSearchForm
        public IActionResult ShowSearchForm()
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

        // GET: Champions/Battle
        public IActionResult Battle()
        {
            return _context.Champion != null ?
                        View() :
                        Problem("Entity set 'ApplicationDbContext.Champion'  is null.");
        }

        // GET: Champions/Details/
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
        public async Task<IActionResult> Create()
        {
            ViewBag.Equipments = await _utilities.GetEquipmentSL();
            return View();
        }

        // POST: Champions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Note for later: Mess with this method to get equipment assigned, add to bind list?????
        public async Task<IActionResult> Create(CreateChampionDTO model)
        {
            ViewBag.Equipments = await _utilities.GetEquipmentSL();
            Champion champion = new Champion();
            if (ModelState.IsValid)
            {
                champion = new Champion()
                {
                    Attack = model.Attack,
                    Defense = model.Defense,
                    Speed = model.Speed,
                    Health = model.Health,
                    EquipmentID = Guid.Parse(model.EquipmentId),
                    Name = model.Name,
                    Bio = model.Bio
                };
                champion.ChampionID = Guid.NewGuid();
                _context.Champion.Add(champion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(champion);
        }

        // GET: Champions/Edit/
        [Authorize]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Champion == null)
            {
                ViewBag.Equipments = await _utilities.GetEquipmentSL();
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
        // Note for later: Same thing here, add bind for Equipment
        public async Task<IActionResult> Edit(Guid id, [Bind("ChampionID,Name,Bio,Attack,Defense,Speed,Health, EquipmentID")] Champion model)
        {

            ViewBag.Equipments = await _utilities.GetEquipmentSL();
            if (id != model.ChampionID)
            {
                return NotFound();
            }
            var champion = await _context.Champion
                .FirstOrDefaultAsync(m => m.ChampionID == id);
            if (champion == null) 
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    champion.Name = model.Name;
                    champion.Bio = model.Bio;
                    champion.Attack = model.Attack;
                    champion.Defense = model.Defense;
                    champion.Speed = model.Speed;
                    champion.Health = model.Health;
                    _context.Update(champion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChampionExists(model.ChampionID))
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
            return View(model);
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
