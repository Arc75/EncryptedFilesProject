using SecuredFilesProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecuredFilesProject.Models.Request
{
    public class LoginModel : IModel
    {
        public string Username { get;  set; }
        public string Password { get;  set; }
        public int Id { get; set; }
    }
}
