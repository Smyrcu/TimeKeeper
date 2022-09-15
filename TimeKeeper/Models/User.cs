using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeKeeper.Models
{
    public class User
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? email { get; set; }
        public int roleId { get; set; }
        public string? token { get; set; }
        public string? phonenumber { get; set; }

        public string FullName => $"{name} {surname}";
    }
}
