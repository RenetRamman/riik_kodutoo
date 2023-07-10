using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EventModelsController : Controller
    {
        private readonly WebApplication1Context _context;

        public EventModelsController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: EventModels
        public async Task<IActionResult> Index()
        {
              return _context.EventModel != null ? 
                          View(await _context.EventModel.ToListAsync()) :
                          Problem("Entity set 'WebApplication1Context.EventModel'  is null.");
        }

        // GET: EventModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EventModel == null)
            {
                return NotFound();
            }

            var eventModel = await _context.EventModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eventModel == null)
            {
                return NotFound();
            }

            return View(eventModel);
        }

        // GET: EventModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Date,Location,AdditionalInfo")] EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventModel);
        }
        
        // GET: EventModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EventModel == null)
            {
                return NotFound();
            }

            var eventModel = await _context.EventModel.FindAsync(id);
            if (eventModel == null)
            {
                return NotFound();
            }
            return View(eventModel);
        }

        // POST: EventModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Date,Location,AdditionalInfo")] EventModel eventModel)
        {
            if (id != eventModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventModelExists(eventModel.ID))
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
            return View(eventModel);
        }

        // GET: EventModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EventModel == null)
            {
                return NotFound();
            }

            var eventModel = await _context.EventModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eventModel == null)
            {
                return NotFound();
            }

            return View(eventModel);
        }

        // POST: EventModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EventModel == null)
            {
                return Problem("Entity set 'WebApplication1Context.EventModel'  is null.");
            }
            var eventModel = await _context.EventModel.FindAsync(id);
            if (eventModel != null)
            {
                _context.EventModel.Remove(eventModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventModelExists(int id)
        {
          return (_context.EventModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
