using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebApplication1Context _context;

        public HomeController(ILogger<HomeController> logger, WebApplication1Context context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.EventModel != null ?
                          View(await _context.EventModel.ToListAsync()) :
                          Problem("Entity set 'WebApplication1Context.EventModel'  is null.");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult UrituseLisamine()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: Home/Osalejad/5
        public async Task<IActionResult> Osalejad(int? id)
        {
            ViewBag.Id = id;
            ViewData["Persons"] = await _context.PersonModel.ToListAsync();
            ViewData["Companies"] = await _context.CompanyModel.ToListAsync();
            ViewData["EventPersons"] = _context.EventPersonModel.Where(s => s.EventModelID == id);
            ViewData["EventCompanies"] = _context.EventCompanyModel.Where(s => s.EventModelID == id);
            /*ViewData["ParticipatingPersons"] = await _context.PersonModel.Include(a => a.Events.Where(w => w.EventModelID == id)).ToListAsync();*/

            /*var query = from m in _context.PersonModel
                        from m2 in _context.EventPersonModel
                        from m3 in _context.EventModel
                        where m.ID == m2.PersonModelID && m2.EventModelID == id
                        select m;*/
            var query = from personmodel in _context.PersonModel
                        from participation in _context.EventPersonModel
                        where personmodel.ID == participation.PersonModelID && participation.EventModelID == id
                        select personmodel;

            ViewData["ParticipatingPersons"] = await query.ToListAsync();

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


    }
}