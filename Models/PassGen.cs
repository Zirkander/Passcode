using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Passcode.Models
{
    public class PassGen
    {
        public int Count { get; set; }
        public string RandPasscode { get; set; }
    }
}