using Etwin.CLS.UploadClass;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using ETwin.BAL.FixModels;
using LogDll;
using Microsoft.AspNetCore.Mvc;
using System;
//using Etwin.Filter;


namespace ETwin_Next.Controllers
{
    // [OperatorCodeFilter]
    public class InputFileController : Controller
    { 
        private readonly ETwinContext data;
        public clsUploadFile clsUploadFile = new clsUploadFile();
        private readonly string _sessionValue;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InputFileController (IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _sessionValue = _httpContextAccessor.HttpContext.Session.GetString("cn");
            data = new ETwinContext(_sessionValue);
        }

        //  [System.Web.Http.HttpPost]
        [HttpPost]
        public async Task<IActionResult> Upload()
        {
            try
            {
                //I take the folder
                string cs = HttpContext.Request.Query["CSOperatorLogin"].ToString();
                var folderFiles = Request.Form.Files;

                IList<AnalysisDrawing> uploadedFiles = new List<AnalysisDrawing>();
                foreach (var file in folderFiles)
                {
                    //I loop through each file and add it to database
                    var stream = file.OpenReadStream();
                    if (file.FileName.Split('.').Last() == "ipt" || file.FileName.Split('.').Last() == "iam" || file.FileName.Split('.').Last() == "dwg")                        
                    using (var memoryStream = new MemoryStream())
                    {
                        AnalysisDrawing modDrawing = new AnalysisDrawing();
                        file.CopyTo(memoryStream);
                        modDrawing.ByteOfFile = memoryStream.ToArray();
                        modDrawing.FileName = file.FileName.ToString();
                        modDrawing.Path = file.Name.ToString();
                        uploadedFiles.Add(modDrawing);

                    }
                }
                clsUploadFile.UploadDrawing(uploadedFiles, cs);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return Ok();

        }
    }
}
