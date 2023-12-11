using Etwin.BAL.BusinnessLogic;
using Etwin.CLS.UploadClass;
using Etwin.Model;
using Etwin.Model.Context;
using ETwin.BAL.FixModels;
using LogDll;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.IO;
//using Etwin.Filter;


namespace ETwin_Next.Controllers
{
    // [OperatorCodeFilter]
    public class DrawingController : Controller
    { 
        private readonly ETwinContext data;
        public clsUploadFile clsUploadFile = new clsUploadFile();
        private readonly string _sessionValue;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BlDocumentArchive blDocument = null;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DrawingController(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _httpContextAccessor = httpContextAccessor;
            _sessionValue = _httpContextAccessor.HttpContext.Session.GetString("cn");
            data = new ETwinContext(_sessionValue);
            blDocument = new BlDocumentArchive(_sessionValue);
            _webHostEnvironment = webHostEnvironment;
        }

        public ActionResult CreateDrawing(int iddisegno)
        {
            var filePath = "";
            DocumentArchive da = blDocument.GetDocumentArchiveById(iddisegno);
            try
            {                
                filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Disegni", da.FileName);

                // Save the byte array as a file
                System.IO.File.WriteAllBytes(filePath, da.Content);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return Content("../Disegni/"+da.FileName);

        }

        public void DeleteFile(string path)
        {
            try
            {
                // delete the file from wwwroot
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                path = path.Replace("..","");
                path = path.Replace("/","\\");
                string filePath = wwwRootPath+ path;

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

        }
    }
}
