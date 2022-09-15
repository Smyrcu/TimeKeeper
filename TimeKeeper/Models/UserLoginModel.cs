using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeKeeper.Models
{
    public class UserLoginModel
    {
        public string email { get; set; }
        public string password { get; set; }

        public UserLoginModel(string userName, string password)
        {
            email = userName;
            this.password = password;
        }
    }
}
