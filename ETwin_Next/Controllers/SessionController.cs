using Microsoft.AspNetCore.Mvc;
using Etwin.BAL.Services;

namespace Etwin1.Controllers
{
    // [TypeFilter(typeof(CustomException))]
    public class SessionController : Controller
    {
        #region VARS
        private readonly AuthenticationService _service;

        #endregion

        #region CONSTRUCTOR
        public SessionController(AuthenticationService service)
        {
            this._service = service;

        }
        #endregion

        public IActionResult GetOperatorCode()
        {
            var sessionData = HttpContext.Session.GetString("opcode"); // I save the operator code in the session
            return Json(sessionData);
        }

        public IActionResult GetCSOperator()
        {
            var sessionData = HttpContext.Session.GetString("cn"); // I save the operator connection string in the session
            return Json(sessionData);
        }

        public IActionResult GetCompanyLogo()
        {
            var sessionData = HttpContext.Session.GetString("companyLogo"); // I save the company logo's path
            return Json(sessionData);
        }
        
        public IActionResult GetCompanyWebsite()
        {
            var sessionData = HttpContext.Session.GetString("companyWebsite"); // Save company's website
            return Json(sessionData);
        }
    }
}