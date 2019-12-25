using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker_API.Models
{
    interface IUserLogIn : IUser
    {
        public string Password { get; set; }

        public bool Login();
    }
}
