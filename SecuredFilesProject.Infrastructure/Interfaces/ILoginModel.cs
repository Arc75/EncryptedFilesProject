using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecuredFilesProject.Infrastructure.Interfaces
{
    public interface ILoginModel : IModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
