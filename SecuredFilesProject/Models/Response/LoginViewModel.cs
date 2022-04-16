using SecuredFilesProject.Models.Response.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecuredFilesProject.Models.Response
{
    public class LoginViewModel : BaseResponse
    {
        public string BarcodeImageUrl { get; internal set; }
        public string SetupCode { get; internal set; }
    }
}
