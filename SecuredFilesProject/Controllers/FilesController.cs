using Microsoft.AspNetCore.Mvc;
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
    public class FilesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "AAAAAAAA";
        }
    }
}
