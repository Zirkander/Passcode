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

            if (HttpContext.Session.GetInt32("count") == null)
            {
                HttpContext.Session.SetInt32("count", 0);
            }
            int count = (int)HttpContext.Session.GetInt32("count");

            if (count >= 0)
            {
                count++;
                HttpContext.Session.SetInt32("count", count);
            }


            PassGen passcode = new PassGen()
            {
                RandPasscode = new string(chars),
                Count = count
            };
            return View("Index", passcode);
        }
    }
}
