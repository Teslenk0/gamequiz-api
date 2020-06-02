using BusinessLogic.Controllers;
using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace HelloWorld.Controller
{
    //[AllowAnonymous]
    [Authorize]
    public class FileUploadingController : ApiController
    {


        private string BASE_URL = System.Configuration.ConfigurationManager.AppSettings["BASE_URL"].ToString();
        private string BASE_PATH = System.Configuration.ConfigurationManager.AppSettings["BASE_IMAGES_PATH"].ToString();

        [HttpPost]
        [Route("api/upload_image")]
        public async Task<Object> UploadFile([FromUri]string tipo, int id)
        {
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~" + this.BASE_PATH);
            var provider =
                new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content
                    .ReadAsMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    var name = file.Headers
                        .ContentDisposition
                        .FileName;

                    // remove double quotes from string.
                    name = name.Trim('"');
                    var completeName = id.ToString() + "-" + name;

                    var localFileName = file.LocalFileName;

                    var filePath = "";
                    if (tipo == "JUEGO")
                    {
                        filePath = Path.Combine(root, "juegos/" + completeName);
                    }
                    else if (tipo == "PREGUNTA")
                    {
                        filePath = Path.Combine(root, "preguntas/" + completeName);
                    }
                    File.Move(localFileName, filePath);

                    if (tipo == "JUEGO")
                    {
                        JuegoController juegoController = new JuegoController();
                        juegoController.SetImage(id, this.BASE_URL + this.BASE_PATH + "/juegos/" + completeName);
                    }
                    else if (tipo == "PREGUNTA")
                    {
                        PreguntaController preguntaController = new PreguntaController();
                        preguntaController.SetImage(id, this.BASE_URL + this.BASE_PATH + "/preguntas/" + completeName);
                    }
                }
                return Content(HttpStatusCode.Created, new ResponseDTO(null, "Se agrego la imagen correctamente", true));
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new ResponseDTO(null, e.Message, false));
            }
        }

        /*[HttpPost]
        [Route("api/upload_image")]
        public async Task<Object> UploadFile([FromUri]string tipo, int id)
        {
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~" + this.BASE_PATH);
            var provider =
                new MultipartFormDataStreamProvider(root);


            

            try
            {
            await Request.Content
                .ReadAsMultipartAsync(provider);
            foreach (var file in provider.FileData)
            {
                var name = file.Headers
                    .ContentDisposition
                    .FileName;


                name = name.Trim('"');

                var completeName = id.ToString() + "-" + name;

                var localFileName = file.LocalFileName;


                var filePath = "";
                if (tipo == "JUEGO")
                {
                    filePath = Path.Combine(root, "/juegos/" + completeName);
                }
                else if (tipo == "PREGUNTA")
                {
                    filePath = Path.Combine(root, "/preguntas/" + completeName);
                }

                

                File.Move(localFileName, filePath);

           
                if (tipo == "JUEGO")
                {
                    JuegoController juegoController = new JuegoController();
                    juegoController.SetImage(id, this.BASE_URL + this.BASE_PATH + "/juegos/" + completeName);
                }
                else if (tipo == "PREGUNTA")
                {
                    PreguntaController preguntaController = new PreguntaController();
                    preguntaController.SetImage(id, this.BASE_URL + this.BASE_PATH + "/preguntas/" + completeName);
                }
            }

            //return new ResponseDTO(BASE_URL+BASE_PATH+"/juegos/"+, "Se subio la imagen correctamente", true);
            return new ResponseDTO(null, "Se subio la imagen correctamente", true);
            //}
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, new ResponseDTO(null, e.Message, false));
            }
        }*/
    }
}
