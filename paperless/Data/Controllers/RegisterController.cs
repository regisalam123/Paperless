using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using paperless.Data.Models;
using paperless.Libs;
using Microsoft.AspNetCore.Http;
using paperless.Manager;
using Microsoft.Win32;

namespace paperless.Data.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private lUser lp = new lUser();
        private lMessage mc = new lMessage();


        [HttpPost]
        public IActionResult Users([FromBody] Register usr)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();

            try
            {
                retData = lp.ReadUser(usr.UserId);
                if (retData.Count > 0)
                {
                    statusCode = 404;
                    jReturn.Add("status", mc.GetMessage("api_output_ok"));
                    jReturn.Add("code", statusCode);
                    jReturn.Add("message", mc.GetMessage("regist_not_found"));
                }
                else
                {
                    string status = lp.Insert(usr);
                    if (status == "success")
                    {
                        jReturn.Add("status", mc.GetMessage("api_output_ok"));
                        jReturn.Add("code", statusCode);
                        jReturn.Add("message", mc.GetMessage("save_success"));
                    }
                    else
                    {
                        statusCode = 404;
                        jReturn.Add("status", mc.GetMessage("api_output_ok"));
                        jReturn.Add("code", statusCode);
                        jReturn.Add("message", mc.GetMessage("save_not_success"));
                    }
                }
            }
            catch (Exception ex)
            {
                statusCode = 500;
                jReturn = new JObject();
                jReturn.Add("status", mc.GetMessage("api_output_not_ok"));
                jReturn.Add("code", statusCode);
                jReturn.Add("message", ex.Message);
            }
            return Content(jReturn.ToString(), "application/json");
        }
    }
}
