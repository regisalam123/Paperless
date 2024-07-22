using paperless.Data.Models;
using paperless.Libs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Drawing;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.IO.Pipelines;
using System.Runtime.CompilerServices;
using System.Buffers.Text;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;

namespace paperless.Data.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LogsheetController : Controller
    {
        private lDbConn dbconn = new lDbConn();
        private BaseController bc = new BaseController();
        private lLogsheet lp = new lLogsheet();
        private lMessage mc = new lMessage();
        private lConvert lc = new lConvert();

        private readonly IWebHostEnvironment environment;
        public LogsheetController (IWebHostEnvironment environment)
        {
            this.environment = environment;

        }
        [Authorize]
        [HttpPost]
        public IActionResult ListLogsheet([FromBody] Logsheet pek)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            String mpi_idpekerjaan = Convert.ToString(pek.Idl.ToString());

            try
            {
                retData = lp.ReadLogsheet (mpi_idpekerjaan);
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
        
        [Authorize]
        [HttpPost]
        public IActionResult ListItemunit([FromBody] Logsheet pek)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            String mpi_idpekerjaan = Convert.ToString(pek.Idl.ToString());

            try
            {
                retData = lp.ReadItemunit (mpi_idpekerjaan);
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

        [Authorize]
        [HttpPost]
        public IActionResult ListLogsheetdetail([FromBody] Logsheet pek)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            String mpi_idpekerjaan = Convert.ToString(pek.Idl.ToString());

            try
            {
                retData = lp.ReadLogsheetdetail(mpi_idpekerjaan);
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

        [Authorize]
        [HttpPost]
        public IActionResult SumbitLogsheet0 ([FromBody] InputLogsheet0 pck)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;

            try
            {
                string status = lp.InsertLogsheet0 (pck);
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
        [Authorize]
        [HttpPost]
        public IActionResult SumbitLogsheet1([FromBody] InputLogsheet1 pck)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;

            try
            {
                string status = lp.InsertLogsheet1(pck);
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
