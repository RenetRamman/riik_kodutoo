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
            ViewData["Persons"] = new PersonModel();
            var queryPerson = from personmodel in _context.PersonModel
                        from participation in _context.EventPersonModel
                        where personmodel.ID == participation.PersonModelID && participation.EventModelID == id
                        select personmodel;
            ViewData["ParticipatingPersons"] = await queryPerson.ToListAsync();
            var queryCompany = from companymodel in _context.CompanyModel
                        from participation in _context.EventCompanyModel
                        where companymodel.ID == participation.CompanyModelID && participation.EventModelID == id
                        select companymodel;
            ViewData["ParticipatingCompanies"] = await queryCompany.ToListAsync();

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

            return View(new ParticipantsViewModel(eventModel));
        }


        // GET: Home/OsalejaEraisik/5
        public async Task<IActionResult> OsalejaEraisik(int? id)
        {
            ViewBag.Id = id;
            if (id == null || _context.PersonModel == null)
            {
                return NotFound();
            }

            var personModel = await _context.PersonModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (personModel == null)
            {
                return NotFound();
            }

            ViewData["person"] = personModel;

            return View(personModel);
        }

        // GET: Home/OsalejaEttevõte/5
        public async Task<IActionResult> OsalejaEttevõte(int? id)
        {
            ViewBag.Id = id;
            if (id == null || _context.CompanyModel == null)
            {
                return NotFound();
            }

            var companyModel = await _context.CompanyModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (companyModel == null)
            {
                return NotFound();
            }

            ViewData["person"] = companyModel;

            return View(companyModel);
        }


        // POST: Home/CreateEvent
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEvent([Bind("ID,Title,Date,Location,AdditionalInfo")] EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventModel);
        }

        // POST: CreatePerson
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePerson(ParticipantsViewModel pm, int? id)
        {

            if (ModelState.IsValid)
            {
                _context.Add(pm.personModel);
                await _context.SaveChangesAsync();

                EventPersonModel eventPerson = new EventPersonModel()
                {
                    PersonModelID = pm.personModel.ID,
                    EventModelID = pm.eventPersonModel.EventModelID
                };
                _context.Add(eventPerson);
                await _context.SaveChangesAsync();
                /*CreateEventPerson(pm.personModel.ID, id);*/
                return RedirectToAction(nameof(Index));
            }
            return View(pm);
        }

        // POST: CreateCompany
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCompany(ParticipantsViewModel pm, int? id)
        {

            if (ModelState.IsValid)
            {
                _context.Add(pm.companyModel);
                await _context.SaveChangesAsync();

                EventCompanyModel eventCompany = new EventCompanyModel()
                {
                    CompanyModelID = pm.companyModel.ID,
                    EventModelID = pm.eventCompanyModel.EventModelID
                };
                _context.Add(eventCompany);
                await _context.SaveChangesAsync();
                /*CreateEventPerson(pm.personModel.ID, id);*/
                return RedirectToAction(nameof(Index));
            }
            return View(pm);
        }

        public async Task<IActionResult> KustutaUritus(int id)
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

        public async Task<IActionResult> KustutaEraisik(int id)
        {
            if (_context.PersonModel == null)
            {
                return Problem("Entity set 'WebApplication1Context.PersonModel'  is null.");
            }
            if (_context.EventPersonModel == null)
            {
                return Problem("Entity set 'WebApplication1Context.EventPersonModel'  is null.");
            }

            var queryEventPerson = from ecm in _context.EventPersonModel
                                    where ecm.PersonModelID == id
                                    select ecm;
            var eventPersonModels = await queryEventPerson.ToListAsync();

            foreach (EventPersonModel ecm in eventPersonModels)
            {
                _context.EventPersonModel.Remove(ecm);
            }
            await _context.SaveChangesAsync();

            var personModel = await _context.PersonModel.FindAsync(id);
            if (personModel != null)
            {
                _context.PersonModel.Remove(personModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> KustutaEttevõte(int id)
        {
            if (_context.CompanyModel == null)
            {
                return Problem("Entity set 'WebApplication1Context.CompanyModel'  is null.");
            }
            if (_context.EventCompanyModel == null)
            {
                return Problem("Entity set 'WebApplication1Context.EventCompanyModel'  is null.");
            }

            var queryEventCompany = from ecm in _context.EventCompanyModel
                               where ecm.CompanyModelID == id
                               select ecm;
            var eventCompanyModels = await queryEventCompany.ToListAsync();

            foreach (EventCompanyModel ecm in eventCompanyModels)
            {
                _context.EventCompanyModel.Remove(ecm);
            }
            await _context.SaveChangesAsync();

            var companyModel = await _context.CompanyModel.FindAsync(id);
            if (companyModel != null)
            {
                _context.CompanyModel.Remove(companyModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        // POST: Home/EditPerson/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPerson(PersonModel pm, int? id)
        {
            if (id != pm.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(pm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCompany(CompanyModel pm, int? id)
        {
            if (id != pm.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(pm);
        }
    }
}