using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker_API.Models
{
    interface IUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
