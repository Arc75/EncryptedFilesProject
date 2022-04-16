using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecuredFilesProject.Models.Request
{
    public class LoginModel
    {
        public string Username { get; internal set; }
        public string Password { get; internal set; }
    }
}
