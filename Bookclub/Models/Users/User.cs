using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Models.Users
{
    public class User 
    {
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
