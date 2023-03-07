using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;

        public AppController(IMailService mailService)
        {
            _mailService = mailService;
        }
        public IActionResult Index()
        {
            //throw new InvalidProgramException("Bad things happen to good developers");
            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            ViewBag.Title = "About Us";

            throw new InvalidOperationException("Bad things happen to good developers");
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            //ViewBag.Title = "Contact Us";
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            //buraya modeli ekledikten sonra viewe gittik ve modeli ekleyerek view importta da using ekleyerek modeli aktif etmiş olduk.

            if (ModelState.IsValid) {
                //send the email

                _mailService.SendMessage("merveceylan152@gmail.com", model.Name, $"From: {model.Email}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();

            }
            else
            {
                //show the errors
            }
            return View();
        }


    }
}
