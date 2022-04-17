using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using SecuredFilesProject.Models.Request;
using SecuredFilesProject.Infrastructure.Models;
using SecuredFilesProject.Infrastructure.Interfaces;

namespace SecuredFilesProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class FilesController : ControllerBase
    {
        IRepository Context => BaseRepository.GetContext();

        [HttpGet]
        public async Task<string> GetA()
        {
            //Save non identifying data to Firebase
            var login = new LoginModel { Username = "1", Password = "1" };
            //var firebaseClient = new FirebaseClient("https://dfiles-f71a3-default-rtdb.europe-west1.firebasedatabase.app/");
            //var result = await firebaseClient
            //  .Child("Users/" + 1 + "/Logins")
            //  .PostAsync(login);

            ////Retrieve data from Firebase
            //var dbLogins = await firebaseClient
            //  .Child("Users")
            //  .Child("1")
            //  .Child("Logins")
            //  .OnceAsync<LoginModel>();

            var context = Context.Add(login).Result;

            var result = ((LoginModel)Context.GetAsync<LoginModel>(0).Result).Password;


            return "AAAAAAAA";
        }
    }
}
