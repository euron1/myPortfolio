using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myPortfolio.Data.Services;
using myPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace myPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactServices _contactServices;

        public HomeController(ILogger<HomeController> logger, IContactServices contactServices)
        {
            _logger = logger;
            _contactServices = contactServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact([Bind("Name, Email, Message")] Contacts contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            await _contactServices.AddAsync(contact);
            ViewBag.Message = "Send Successfully";

            /*int id = contact.Id*/
            ;
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Contact(int id)
        {
            var contactDetails = await _contactServices.GetByIdAsync(id);

            if (contactDetails == null) return View("NotFound");
            return View(contactDetails);
        }

        public IActionResult Privacy()
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
