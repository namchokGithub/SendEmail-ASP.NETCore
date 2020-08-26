using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmailApp.Models;
using EmailService;

namespace EmailApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender _emailSender;

        public HomeController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Index()
        {

            

            return View();
        }

        [HttpGet]
        public void emailSended()
        {
            var message = new Message(
                    new string[] { "pech4751@gmail.com" },
                    "So hungy",
                    "This message is the content from MHEE"
                );

            _emailSender.SendEmail(message);
        }        
        
        [HttpGet]
        public async Task emailSendedAsync()
        {
            var message = new Message(
                    new string[] { "pech4751@gmail.com" },
                    "So hungy",
                    "(Async) This message is the content from MHEE"
                );

            await _emailSender.SendEmailAsync(message);
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
