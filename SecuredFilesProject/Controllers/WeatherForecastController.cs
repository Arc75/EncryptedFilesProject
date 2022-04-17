using Google.Authenticator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecuredFilesProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private const string key = "1234";

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public Models.Response.LoginViewModel Login(string userName, string password)
        {
            string message = "";
            bool status = false;
            var response = new Models.Response.LoginViewModel();

            if (userName == "Admin" && password == "Password1")
            {
                status = true; // show 2FA form
                message = "2FA Verification";

                //2FA Setup
                var tfa = new TwoFactorAuthenticator();
                var setupInfo = tfa.GenerateSetupCode("Dotnet Awesome", userName, key, false, 300);
                response.BarcodeImageUrl = setupInfo.QrCodeSetupImageUrl;
                response.SetupCode = setupInfo.ManualEntryKey;
            }
            else
            {
                message = "Invalid credential";
            }
            response.Message = message;
            response.Status = status;

            return new Models.Response.LoginViewModel();
        }

        public ActionResult Verify2FA(string code)
        {
            var token = code;
            var tfa = new TwoFactorAuthenticator();
            bool isValid = tfa.ValidateTwoFactorPIN(key, token);
            if (isValid)
            {
                return RedirectToAction("MyProfile", "Home");
            }
            return RedirectToAction("Login", "Home");
        }
    }
}
