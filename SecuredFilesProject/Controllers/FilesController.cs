using Microsoft.AspNetCore.Mvc;
using SecuredFilesProject.Infrastructure.Interfaces;
using SecuredFilesProject.Infrastructure.Models;
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
        IRepository Context => BaseRepository.GetContext();

        [HttpGet]
        public async Task<string> GetA()
        {
            //Save non identifying data to Firebase
            var login = new LoginRepositoryModel { Email = "1", Password = "1" };
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

            var result = ((LoginRepositoryModel)Context.GetAsync<LoginRepositoryModel>(0).Result).Password;


            return "AAAAAAAA";
        }
    }
}
