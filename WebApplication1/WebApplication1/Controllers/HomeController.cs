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


    }
}