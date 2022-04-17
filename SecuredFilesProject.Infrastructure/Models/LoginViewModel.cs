using SecuredFilesProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecuredFilesProject.Infrastructure.Models
{
    public class LoginViewModel: ILoginModel
    {
        public string Password { get;  set; }
        public string Email { get; set; }
        public int Id { get; set; }
    }
}
