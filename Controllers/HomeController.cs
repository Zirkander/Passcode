using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Passcode.Models;

namespace Passcode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            var validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            Random rChar = new Random();
            char[] chars = new char[14];
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = validChars[rChar.Next(validChars.Length)];
            }



            PassGen passcode = new PassGen()
            {
                RandPasscode = new string(chars),
                Count = +1
            };

            PassGen count = new PassGen()
            {
                Count = 0
            };


            return View("Index", passcode);
        }


    }
}
