using paperless.Data.Models;
using paperless.Libs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Npgsql;
using System.Data;
using System.Reflection.Emit;

namespace paperless.Data.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PerananController : Controller
    {
        private lDbConn dbconn = new lDbConn();
        private BaseController bc = new BaseController();
        private lPeranan lp = new lPeranan();
        private lMessage mc = new lMessage();
        private lConvert lc = new lConvert();

        [HttpPost]
        public IActionResult ListPeranan([FromBody] Peranan per)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            String mpi_idperanan = Convert.ToString(per.IdPeranan.ToString());
            List<dynamic> retData = new List<dynamic>();

            try
            {
                retData = lp.ReadPeranan(mpi_idperanan);
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

        [HttpPost]
        public IActionResult ListPeriode([FromBody] Periode prd)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            String mpi_id = Convert.ToString(prd.Id.ToString());
            String mpi_uraianid = Convert.ToString(prd.UraianId.ToString());
            List<dynamic> retData = new List<dynamic>();

            try
            {
                retData = lp.ReadPeriode(mpi_id,mpi_uraianid);
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
