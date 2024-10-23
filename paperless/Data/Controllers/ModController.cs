using paperless.Data.Models;
using paperless.Libs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace paperless.Data.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ModController : Controller
    {
        private lDbConn dbconn = new lDbConn();
        private BaseController bc = new BaseController();
        private lPekerjaanmod lp = new lPekerjaanmod();
        private lMessage mc = new lMessage();
        private lConvert lc = new lConvert();

        private readonly IWebHostEnvironment environment;

        [Authorize]
        [HttpGet]
        public IActionResult ListPekerjaanMOD()
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();

            // Berikan nilai default, misalnya string kosong atau ID khusus
            string defaultIdm = "default_value"; // Sesuaikan dengan nilai yang valid
            try
            {
                // Panggil metode dengan nilai default
                retData = lp.ReadPekerjaanmod(defaultIdm);
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
        [HttpGet]
        public IActionResult ListPekerjaanMODDETAIL([FromQuery] string idm)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();

            //Jika idm kosong, berikan nilai default
            string idmValue = string.IsNullOrEmpty(idm) ? "default_value" : idm;

            try
            {
                //Panggil metode dengan nilai idm yang diterima dari query
                retData = lp.ReadPekerjaanmoddetail(idmValue);
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
        public IActionResult SumbitMOD([FromBody] InputMod0 pck)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;

            try
            {
                string status = lp.Insertmod0(pck);
                if (status == "success")
                {
                    string status2 = lp.Insertmod1(pck);
                    if (status2 == "success")


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


        /*  [Authorize]
          [HttpPost]
          public IActionResult ListFilterpekerjaanMOD([FromBody] Filterpekerjaanmod fil)
          {
              JObject jReturn = new JObject();
              var statusCode = 200;
              List<dynamic> retData = new List<dynamic>();
              String mpi_idpekerjaan1 = Convert.ToString(fil.Tanggalaw.ToString());
              String mpi_idpekerjaan2 = Convert.ToString(fil.Tanggalak.ToString());

              try
              {
                  retData = lp.ReadFiltermod(mpi_idpekerjaan1, mpi_idpekerjaan2);
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
  */
        [Authorize]
        [HttpGet]
        public IActionResult ListFilterpekerjaanMOD([FromQuery] string tanggalAw, [FromQuery] string tanggalAk)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();

            try
            {
                // Mengonversi parameter menjadi string
                String mpi_idpekerjaan1 = Convert.ToString(tanggalAw);
                String mpi_idpekerjaan2 = Convert.ToString(tanggalAk);

                retData = lp.ReadFiltermod(mpi_idpekerjaan1, mpi_idpekerjaan2);
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
        [HttpGet]
        public IActionResult ListFilterTRXMOD([FromQuery] string idtrx)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();

            try
            {
                
                String mpi_idpekerjaan1 = Convert.ToString(idtrx);
               

                retData = lp.ReadFiltertrxmod(mpi_idpekerjaan1);
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
        [HttpPut]
        public IActionResult UpdateMOD([FromBody] ModUpdate0 pck)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;

            try
            {
                string status = lp.Updatemod0(pck);
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
        public IActionResult InsertSession([FromBody] ModSession pck)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;

            try
            {
                string status = lp.Insertsessionmod(pck);
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
        [HttpGet]
        public IActionResult ListSessionMOD([FromQuery] string userid, [FromQuery] string status, [FromQuery] string tanggal)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();

            try
            {
                // Mengonversi parameter menjadi string
                String mpi_idpekerjaan1 = Convert.ToString(userid);
                String mpi_idpekerjaan2 = Convert.ToString(status);
                String mpi_idpekerjaan3 = Convert.ToString(tanggal);


                retData = lp.GetSessionmod(mpi_idpekerjaan1, mpi_idpekerjaan2, mpi_idpekerjaan3);
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
        [HttpPut]
        public IActionResult UpdatesessionMOD([FromBody] ModSession pck)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;

            try
            {
                string status = lp.Updatesessionmod(pck);
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
