using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using paperless.Manager;
using paperless.Libs;
using Newtonsoft.Json.Linq;
using paperless.Data.Models;

namespace paperless.Data.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : ControllerBase
    {
#pragma warning disable CS8604 // Possible null reference argument.
        private lUser lp = new lUser();
        private lMessage mc = new lMessage();
        private lConvert lc = new lConvert();

        private readonly JwtAuthenticationManager jwtAuthenticationManager;
        public LoginController(JwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Authorize([FromBody] User usr)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            var jsonObject = new JObject();
            dynamic data = jsonObject;
            data.Lists = new JArray() as dynamic;
            JObject jToken = new JObject();

            try
            {
                var token = jwtAuthenticationManager.Authenticate(usr.UserId, usr.Password);
                jToken.Add("Token", token);
                data.Lists.Add(jToken);
                if (!string.IsNullOrEmpty(token))
                {
                    jReturn.Add("status", mc.GetMessage("api_output_ok"));
                    jReturn.Add("code", statusCode);
                    jReturn.Add("data", value: data.Lists);
                }
                else
                {
                    statusCode = 404;
                    jReturn.Add("status", mc.GetMessage("api_output_ok"));
                    jReturn.Add("code", statusCode);
                    jReturn.Add("message", mc.GetMessage("read_not_found"));
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

            //if (string.IsNullOrEmpty(token))
            //    return Unauthorized();
            //return Ok(token);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Users([FromBody] User usr)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();

            try
            {
                retData = lp.ReadUser2(usr.UserId, usr.Password);

                if (retData.Count > 0)
                {

                    jReturn.Add("status", mc.GetMessage("api_output_ok"));
                    jReturn.Add("code", statusCode);
                    jReturn.Add("data", lc.ConvertDynamicToJArray(retData, ""));
                }

                else
                {
                    statusCode = 404;
                    jReturn.Add("status", mc.GetMessage("api_output_ok"));
                    jReturn.Add("code", statusCode);
                    jReturn.Add("message", mc.GetMessage("user_not_found"));
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
#pragma warning restore CS8604 // Possible null reference argument.
}