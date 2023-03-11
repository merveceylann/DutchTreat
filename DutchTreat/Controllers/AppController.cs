using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        //private readonly DutchContext _context;
        private readonly IDutchRepository _repo;


        public AppController(IMailService mailService, IDutchRepository repo)
        {
            _mailService = mailService;
            _repo = repo;
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

            if (ModelState.IsValid)
            {
                //send the email

                //_mailService.SendMessage("merveceylan152@gmail.com", model.Name, $"From: {model.Email}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();

            }
            else
            {
                //show the errors
            }
            return View();
        }
        [HttpGet("contact2")]
        public IActionResult Contact2()
        {
            //ViewBag.Title = "Contact Us";
            return View();
        }

        [HttpPost("contact2")]
        public IActionResult Contact2(ContactViewModel model)
        {
            //buraya modeli ekledikten sonra viewe gittik ve modeli ekleyerek view importta da using ekleyerek modeli aktif etmiş olduk.

            if (ModelState.IsValid)
            {
                //send the email

                //_mailService.SendMessage("merveceylan152@gmail.com", model.Name, $"From: {model.Email}");
                //if (model.Name > 0 && model.Name < 5 )
                //{
                //    ViewBag.UserMessage = "result : 50";
                //}
                //else if (model.Name >= 5 && model.Name <= 10)
                //{
                //    ViewBag.UserMessage = "result : 60";
                //}
                //else if (model.Name > 10 && model.Name <= 14)
                //{
                //    ViewBag.UserMessage = "result : 70";
                //}
                //else if (model.Name > 14 && model.Name <= 20)
                //{
                //    ViewBag.UserMessage = "result : 90";
                //}
                //else
                //{
                //    ViewBag.UserMessage = "error";
                //}

                if (model.Name > 0 && model.Name < 5)
                {
                    ViewBag.UserMessage = "result : 50";
                }
                else if (model.Name <= 5 && model.Name <= 10)
                {
                    ViewBag.UserMessage = "result : 60";
                }
                else if (model.Name < 10 && model.Name <= 14)
                {
                    ViewBag.UserMessage = "result : 70";
                }
                else if (model.Name < 14 && model.Name <= 20)
                {
                    ViewBag.UserMessage = "result : 90";
                }
                else
                {
                    ViewBag.UserMessage = "error";
                }


                ModelState.Clear();

            }
            else
            {
                //show the errors
            }
            return View();
        }

        public IActionResult Shop()
        {
            //var results = _context.Products
            //    .OrderBy(p => p.Category)
            //    .ToList(); 

            //var results = from p in _context.Products
            //              orderby p.Category
            //              select p;

            var results = _repo.GetAllProducts();
            return View(results);
        }
    }
}
