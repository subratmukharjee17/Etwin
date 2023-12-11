using Etwin.BAL.BusinnessLogic;
using Etwin.Model;
using Etwin.Model.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;



namespace ETwin_Next.Controllers
{
    public class ReportsController : Controller
    {

        private readonly ETwinContext _data;
        private readonly string _sessionValue;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReportsController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _sessionValue = _httpContextAccessor.HttpContext.Session.GetString("cn");
            _data = new ETwinContext(_sessionValue);
        }

        //[HttpHead]
        public IActionResult DownloadFile(int fileId)
        {
            //I get the table row from the file id
            BlDocumentArchive blDocumentArchive = new BlDocumentArchive();
            DocumentArchive da = blDocumentArchive.GetDocumentArchiveById(fileId);

            if (da == null)
            {
                return NotFound();
            }
            
            string contentType = "application/pdf";
            //I recreate the file
            return PhysicalFile(da.FullPathEtwin, contentType, da.FileName);
        }

    }
}
