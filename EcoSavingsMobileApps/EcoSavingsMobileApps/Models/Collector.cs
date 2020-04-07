using System;
using System.Collections.Generic;
using System.Text;

namespace EcoSavingsMobileApps.Models
{
    class Collector : User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int TotalPoints { get; set; }
        public string Address { get; set; }
    }
}
