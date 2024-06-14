using paperless.Libs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Npgsql;
using System.Data;
using System.Reflection.Emit;
using paperless.Data.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;

namespace paperless.Data.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private lDbConn dbconn = new lDbConn();
        private BaseController bc = new BaseController();
        private lUser lp = new lUser();
        private lMessage mc = new lMessage();
        private lConvert lc = new lConvert();


        [HttpPost("ResetPwd")]
        public IActionResult ResetPwd([FromBody] User user)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            List<dynamic> retData2 = new List<dynamic>();

            try
            {
                retData = lp.ReadUser(user.UserId);
                if (retData.Count > 0)
                {
                    retData2 = lp.ResetUsrPwd(user.UserId);
                    if (retData2.Count > 0)
                    {
                        jReturn.Add("status", mc.GetMessage("api_output_ok"));
                        jReturn.Add("code", statusCode);
                        jReturn.Add("data", lc.ConvertDynamicToJArray(retData2, "NewPassword"));
                    }
                    else
                    {
                        statusCode = 404;
                        jReturn.Add("status", mc.GetMessage("api_output_ok"));
                        jReturn.Add("code", statusCode);
                        jReturn.Add("message", mc.GetMessage("update_not_success"));
                    }

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
        }


        [HttpPost("ReadIdreg")]
        public IActionResult ReadId([FromBody] RegisterId ri)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();

            try
            {
                retData = lp.ReadId(ri.IdR);

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
}
