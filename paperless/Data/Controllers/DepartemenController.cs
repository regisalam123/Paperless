using paperless.Data.Models;
using paperless.Libs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Npgsql;
using System.Data;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;

namespace paperless.Data.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartemenController : Controller
    {
        private lDbConn dbconn = new lDbConn();
        private BaseController bc = new BaseController();
        private lDepartemen lp = new lDepartemen();
        private lMessage mc = new lMessage();
        private lConvert lc = new lConvert();

        [HttpPost]
        public IActionResult ListDepartemen([FromBody] Departemen dpt)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            String mpi_iddepartemen = Convert.ToString(dpt.IdDepartemen.ToString());
            List<dynamic> retData = new List<dynamic>();

            try
            {
                retData = lp.ReadDepartemen(mpi_iddepartemen);
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
    }
}
