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



namespace paperless.Data.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PekerjaanController : Controller
    {
        private lDbConn dbconn = new lDbConn();
        private BaseController bc = new BaseController();
        private lPekerjaan lp = new lPekerjaan();
        private lMessage mc = new lMessage();
        private lConvert lc = new lConvert();

        private readonly IWebHostEnvironment environment;
       
        public PekerjaanController(IWebHostEnvironment environment)
        {
            this.environment = environment;
          
        }

        [Authorize]
        [HttpPost]
        public IActionResult ListPekerjaan([FromBody] Pekerjaan pek)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            String mpi_idpekerjaan = Convert.ToString(pek.IdPekerjaan.ToString());

            try
            {
                retData = lp.ReadPekerjaan(mpi_idpekerjaan);
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
        public IActionResult ListFilter([FromBody] FilterPekerjaan fil)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            String mpi_idpekerjaan1 = Convert.ToString(fil.Tanggalaw.ToString());
            String mpi_idpekerjaan2 = Convert.ToString(fil.Tanggalak.ToString());

            try
            {
                retData = lp.ReadFilter (mpi_idpekerjaan1,mpi_idpekerjaan2);
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
        public IActionResult ListPekerjaanUpdate([FromBody] PekerjaanUpdate peku)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            String mpi_idpekerjaan = Convert.ToString(peku.IdPekerjaan.ToString());

            try
            {
                retData = lp.ReadPekerjaanUpdate(mpi_idpekerjaan);
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
        public IActionResult ListJob([FromBody] Job pek)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            String mpi_idpekerjaan = Convert.ToString(pek.IdForm.ToString());
        
            try
            {
                retData = lp.Readjob(mpi_idpekerjaan);
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
        public IActionResult DeletePekerjaan2([FromBody] DeletePekerjaan dpk)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            String mpi_idpekerjaan = Convert.ToString(dpk.Eid.ToString());

            try
            {
                retData = lp.Deletejob2(mpi_idpekerjaan);
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
        public IActionResult DeletePekerjaan3([FromBody] DeletePekerjaan dpk)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            String mpi_idpekerjaan = Convert.ToString(dpk.Eid.ToString());

            try
            {
                retData = lp.Deletejob3(mpi_idpekerjaan);
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
        public IActionResult ListCeklistPekerjaan([FromBody] Pekerjaan pek)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            String mpi_idpekerjaan = Convert.ToString(pek.IdPekerjaan.ToString());
            String mpi_ischeck = Convert.ToString(pek.IsCheck.ToString());

            try
            {
                retData = lp.ReadCeklistPekerjaan(mpi_idpekerjaan,mpi_ischeck);
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
        public IActionResult ListAllCeklistPekerjaan([FromBody] Pekerjaanck fpek)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            String mpi_iduser = Convert.ToString(fpek.UserId.ToString());
            String mpi_idpekerjaan = Convert.ToString(fpek.IdPekerjaan.ToString());
            String mpi_ischeck = Convert.ToString(fpek.IsCheck.ToString());

            try
            {
                retData = lp.ReadAllCeklist(mpi_iduser, mpi_idpekerjaan, mpi_ischeck);
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

        [NonAction]
        private string GetFilepath()
        {
            return this.environment.WebRootPath + "\\Gambar\\";
        }



        [Authorize]
        [HttpPost]
        public async Task<JObject> SaveImageAsync(string imageBase64, string imageBase64_2, string nama)
        {
            var jRet = new JObject();

            // var filePath = this.environment.WebRootPath;

            string Filepath = GetFilepath();


            if (!System.IO.Directory.Exists(Filepath))
            {
                System.IO.Directory.CreateDirectory(Filepath);
            }
             string imageName = nama+"_C01";
            string imageName_2 = nama+"_C02";


            string fullPath = Filepath + imageName + ".jpeg";
            string fullPath_2 = Filepath + imageName_2 + ".jpeg";


            byte[] imageBytes = Convert.FromBase64String(imageBase64);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);


            byte[] imageBytes_2 = Convert.FromBase64String(imageBase64_2);
            MemoryStream ms_2 = new MemoryStream(imageBytes_2, 0, imageBytes_2.Length);
            ms_2.Write(imageBytes_2, 0, imageBytes_2.Length);
            System.Drawing.Image image_2 = System.Drawing.Image.FromStream(ms_2, true);





               await Task.Delay(1000);
            image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            await Task.Delay(1000);
            image_2.Save(fullPath_2, System.Drawing.Imaging.ImageFormat.Jpeg);
               await Task.Delay(1000);



            return jRet;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SumbitCeklistPekerjaan([FromBody] Pekerjaanck2 pck)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;  



            try
            {

                string imageBase64 = pck.Foto.ToString();

                string imageBase64_2 = pck.Foto2.ToString();

              if (imageBase64.Substring(11, 4) == "jpeg")
                {
                    imageBase64 = imageBase64.Replace("data:image/jpeg;base64,", "");

                }
                if (imageBase64_2.Substring(11, 4) == "jpeg")
                {
                    imageBase64_2 = imageBase64_2.Replace("data:image/jpeg;base64,", "");

                }


            

                  this.SaveImageAsync(imageBase64, imageBase64_2,pck.Id.ToString());
                await Task.Delay(1000);


                string status = lp.InsertCeklistPekerjaan1(pck);
                if (status == "success")
                {
                    string status2 = lp.InsertCeklistPekerjaan2(pck);
                    if (status2 == "success")
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
        public IActionResult SumbitCeklistPekerjaannonck([FromBody] Pekerjaannonck pck)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;

            try
            {
                string status = lp.InsertCeklistPekerjaannonck(pck);
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
        public IActionResult ListPendingPekerjaan([FromBody] PendingPekerjaan fpek)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            String mpi_idpekerjaan = Convert.ToString(fpek.Maker.ToString());

            try
            {
                retData = lp.ReadPendingPekerjaan(mpi_idpekerjaan);
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
        public IActionResult ListFormPekerjaan([FromBody] FormPekerjaan fpek)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            String mpi_idpekerjaan = Convert.ToString(fpek.Id.ToString());

            try
            {
                retData = lp.ReadFormPekerjaan(mpi_idpekerjaan);
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
        public IActionResult LoadDataLama2 ([FromBody] PekerjaanUpdate Peku)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            String mpi_idpekerjaan = Convert.ToString(Peku.IdPekerjaan.ToString());

            try
            {
                retData = lp.LoadDataLama2(mpi_idpekerjaan);
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
        public IActionResult LoadDataLama3([FromBody] PekerjaanUpdate Pekup)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            String mpi_idpekerjaan = Convert.ToString(Pekup.IdPekerjaan.ToString());

            try
            {
                retData = lp.LoadDataLama3(mpi_idpekerjaan);
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
        public IActionResult ListCeklistFormPekerjaan([FromBody] FormPekerjaanck fpek)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;
            List<dynamic> retData = new List<dynamic>();
            List<dynamic> retData2 = new List<dynamic>();
            String mpi_idpekerjaan = Convert.ToString(fpek.IdPekerjaan.ToString());
            String mpi_id = Convert.ToString(fpek.Id.ToString());
            String mpi_uraian= Convert.ToString(fpek.Uraian.ToString());

            try
            {
               
                    retData2 = lp.ReadAllFormCeklist(mpi_id, mpi_idpekerjaan, mpi_uraian);
                    if (retData2.Count > 0)
                    {
                        jReturn.Add("status", mc.GetMessage("api_output_ok"));
                        jReturn.Add("code", statusCode);
                      
                        jReturn.Add("data2", lc.ConvertDynamicToJArray(retData2, ""));
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
        public async Task<JObject> SaveImageAsync2(string imageBase64, string imageBase64_2, string imageBase64_3, string nama)
        {
            var jRet = new JObject();

            // var filePath = this.environment.WebRootPath;

            string Filepath = GetFilepath();


            if (!System.IO.Directory.Exists(Filepath))
            {
                System.IO.Directory.CreateDirectory(Filepath);
            }
            string imageName = nama + "_P01";
            string imageName_2 = nama + "_P02";
            string imageName_3 = nama + "_P03";

            string fullPath = Filepath + imageName + ".jpeg";
            string fullPath_2 = Filepath + imageName_2 + ".jpeg";
            string fullPath_3 = Filepath + imageName_3 + ".jpeg";


            byte[] imageBytes = Convert.FromBase64String(imageBase64);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);


            byte[] imageBytes_2 = Convert.FromBase64String(imageBase64_2);
            MemoryStream ms_2 = new MemoryStream(imageBytes_2, 0, imageBytes_2.Length);
            ms_2.Write(imageBytes_2, 0, imageBytes_2.Length);
            System.Drawing.Image image_2 = System.Drawing.Image.FromStream(ms_2, true);

            byte[] imageBytes_3 = Convert.FromBase64String(imageBase64_3);
            MemoryStream ms_3 = new MemoryStream(imageBytes_3, 0, imageBytes_3.Length);
            ms_3.Write(imageBytes_3, 0, imageBytes_3.Length);
            System.Drawing.Image image_3 = System.Drawing.Image.FromStream(ms_3, true);


            await Task.Delay(1000);
            image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            await Task.Delay(1000);
            image_2.Save(fullPath_2, System.Drawing.Imaging.ImageFormat.Jpeg);
            await Task.Delay(1000);
            image_3.Save(fullPath_3, System.Drawing.Imaging.ImageFormat.Jpeg);
            await Task.Delay(1000);



            return jRet;
        }



        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SumbitCeklistFormPekerjaan([FromBody] FormPekerjaanck2 fpck)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;


                try
                {

                string imageBase64 = fpck.foto3.ToString();

                string imageBase64_2 = fpck.foto4.ToString();

                string imageBase64_3 = fpck.foto5.ToString();

                if (imageBase64.Substring(11, 4) == "jpeg")
                {
                    imageBase64 = imageBase64.Replace("data:image/jpeg;base64,", "");

                }
                if (imageBase64_2.Substring(11, 4) == "jpeg")
                {
                    imageBase64_2 = imageBase64_2.Replace("data:image/jpeg;base64,", "");

                }
                if (imageBase64_3.Substring(11, 4) == "jpeg")
                {
                    imageBase64_3 = imageBase64_3.Replace("data:image/jpeg;base64,", "");

                }



                this.SaveImageAsync2(imageBase64, imageBase64_2, imageBase64_3, fpck.Id.ToString());
                await Task.Delay(1000);



                string status = lp.InsertCeklistFormPekerjaan1(fpck);
                if (status == "success")
                {                    
                    string status2 = lp.InsertCeklistFormPekerjaan2(fpck);
                    if (status2 == "success")
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
        public async Task<IActionResult> UpdateCeklistFormPekerjaan([FromBody] FormPekerjaanck2u fpcku)
        {
            JObject jReturn = new JObject();
            var statusCode = 200;


            try
            {

                string imageBase64 = fpcku.foto3.ToString();

                string imageBase64_2 = fpcku.foto4.ToString();

                string imageBase64_3 = fpcku.foto5.ToString();

                if (imageBase64.Substring(11, 4) == "jpeg")
                {
                    imageBase64 = imageBase64.Replace("data:image/jpeg;base64,", "");

                }
                if (imageBase64_2.Substring(11, 4) == "jpeg")
                {
                    imageBase64_2 = imageBase64_2.Replace("data:image/jpeg;base64,", "");

                }
                if (imageBase64_3.Substring(11, 4) == "jpeg")
                {
                    imageBase64_3 = imageBase64_3.Replace("data:image/jpeg;base64,", "");

                }



                this.SaveImageAsync2(imageBase64, imageBase64_2, imageBase64_3, fpcku.Id.ToString());
                await Task.Delay(1000);



                string status = lp.UpdateCeklistFormPekerjaan1(fpcku);
                if (status == "success")
                {
                    string status2 = lp.UpdateCeklistFormPekerjaan2(fpcku);
                    if (status2 == "success")
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
