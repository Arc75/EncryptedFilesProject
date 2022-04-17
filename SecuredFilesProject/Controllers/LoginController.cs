using Microsoft.AspNetCore.Mvc;
using SecuredFilesProject.Infrastructure.Interfaces;
using SecuredFilesProject.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace SecuredFilesProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class LoginController : ControllerBase
    {
        IRepository Context => BaseRepository.GetContext();

        [HttpPost]
        public async Task<bool> Post(LoginViewModel login)
        {
            await Context.AuthorizeAsync(login);

            return true;
        }
    }
}
