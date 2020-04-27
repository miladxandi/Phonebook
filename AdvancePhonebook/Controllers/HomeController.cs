using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AdvancePhonebook.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdvancePhonebook.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancePhonebook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            
            ViewData["Title"] = "نتایج";
            return View(await _context.Enterprises.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}