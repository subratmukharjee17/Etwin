using Microsoft.AspNetCore.Mvc;
using LogDll;
using Etwin.BAL.BusinnessLogic;
using Etwin.Helper.ConstantHelper;
using Etwin.BAL.Services;
using Etwin.DAL.Models;
using Newtonsoft.Json.Linq;

namespace Etwin1.Controllers
{
    // [TypeFilter(typeof(CustomException))]
    public class OperatorsController : Controller
    {
        #region VARS
        private readonly BlOperators blOperators;
        private const string UserIDCookieKey = "userID";
        private readonly AuthenticationService _service;
        private readonly BlLogin blLogin;
        private IConfiguration _conf;

        #endregion

        #region CONSTRUCTOR
        public OperatorsController(AuthenticationService service, IConfiguration configuration)
        {
            this._service = service;
            this._conf = configuration;
            this.blLogin = new BlLogin(configuration);

        }
        #endregion


        #region LOGIN VIEW
        [HttpGet]
        public ActionResult LoginView()
        {
            if (HttpContext.Request.Cookies.ContainsKey(UserIDCookieKey))
            {
                ViewBag.userID = GetCookie(UserIDCookieKey);
            }
            return View();
        }
        #endregion

        #region MANAGE COOKIES
        private void SetCookie(string key, string value)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Append(key, value, option);
        }
        private string GetCookie(string key)
        {
            return Request.Cookies[key];
        }
        private void DeleteCookie(string key)
        {
            Response.Cookies.Delete(key);
        }
        #endregion

        #region AUTHENTICATION
        [HttpPost]
        //[ValidateAntiForgeryToken]

        public ActionResult Authentication(string Username, string Password, string RememberUser)
        {
            Operator OperatorDetails = blLogin.GetOperator(Username, Password, null);

            var session = HttpContext.Session;

            if (Username == null)
            {
                return View();
            }

            if (OperatorDetails != null)
            {
                Companies companies = blLogin.GetConnectionOfOperator(OperatorDetails.IdCompany);
                //getting details from his company DB
                Etwin.Model.Operator Op = blLogin.GetOperatorFromCompany(Username, Password, companies.ConnectionString);
                session.SetString("cn", companies.ConnectionString);

                //WRITE THE CS IN THE APPSETTINGS.JSON

                this.WriteCsInAppsettings(companies.ConnectionString);

                string name = HttpContext.Session.GetString(Username);
                session.SetString("NameSurname", OperatorDetails.NameSurname);
                //TempData["Key"] = OperatorDetails.NameSurname;
                session.SetString("UserName", OperatorDetails.Username);
                if (RememberUser == "true")
                    SetCookie(UserIDCookieKey, Username);
                else
                    DeleteCookie(UserIDCookieKey);

                string oprcode = Convert.ToString(OperatorDetails.IdOperator);

                session.SetString("opcode", Op.OperatorCode);
                session.SetString("companyLogo", companies.CompanyLogo);
                session.SetString("companyWebsite", companies.WebSite);
                //return RedirectToAction("Index", "DepartmentAccess", TempData["Key"]);
                return RedirectToAction("Index", "Department");
            }
            else
            {
                return new ContentResult() { Content = ConstantMessage.InvalidCredential };
            }

        }
        #endregion

        #region PASSWORD RECOVERY
        [HttpGet]
        public ActionResult PasswordRecovery()
        {
            return View();
        }
        #endregion

        #region PASSWORD RECOVERY EMAIL
        [HttpPost]
        public async Task<ActionResult> PasswordRecoveryEmail(string Username)
        {

            var ErrorMessage = await _service.SendEmail(Username);

            if (ErrorMessage)
            {
                TempData["RecoveryMessage"] = ConstantMessage.RecoveryMessageSuccess;
            }
            else
            {
                TempData["RecoveryMessage"] = ConstantMessage.RecoveryMessageFail;
            }
            TempData.Keep("RecoveryMessage");
            return View("PasswordRecovery");
        }
        #endregion

        #region WRITE CS IN APPSETTINGS
        private void WriteCsInAppsettings(string cs)
        {
            try
            {
                string jsonPath = "appsettings.json";

                //SET NULL IF THERE IS ALREADY A CS
                string jsonContentNull = System.IO.File.ReadAllText(jsonPath);
                JObject jsonObjNull = JObject.Parse(jsonContentNull);
                jsonObjNull["ConnectionStrings"]["CsCust"] = ""; // Sostituisci con il tuo nuovo valore
                string updatedJsonContentNull = jsonObjNull.ToString();
                System.IO.File.WriteAllText(jsonPath, updatedJsonContentNull);


                //READ FILE CONTENT
                string jsonContent = System.IO.File.ReadAllText(jsonPath);
                JObject jsonObj = JObject.Parse(jsonContent);
                jsonObj["ConnectionStrings"]["CsCust"] = cs; // Sostituisci con il tuo nuovo valore
                string updatedJsonContent = jsonObj.ToString();
                System.IO.File.WriteAllText(jsonPath, updatedJsonContent);

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        #endregion

    }
}