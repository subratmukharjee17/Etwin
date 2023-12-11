using Etwin.BAL.BusinnessLogic;
using Etwin.DAL.Models;
using Etwin.Model;
using LogDll;
using Microsoft.AspNetCore.Mvc;

namespace ETwin_Next.Controllers
{
    public class InputControlPopupController : Controller
    {
        #region VARIABLE
        private readonly BlPhaseConstraints blConstraints = null;
        private readonly BlGeneric blGeneric = null;
        private readonly BlInputControl blInputControl = null;
        private readonly string _sessionValue;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region CONSTRUCTOR
        public InputControlPopupController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _sessionValue = _httpContextAccessor.HttpContext.Session.GetString("cn");
            this.blConstraints = new BlPhaseConstraints(_sessionValue);
            this.blGeneric = new BlGeneric(_sessionValue);
            this.blInputControl = new BlInputControl(_sessionValue);
        }
        #endregion

        #region GET VIEW
        [HttpGet]
        public IActionResult GetView(InputControlPageViewModel inputControlPageViewModel)
        {
            return View(inputControlPageViewModel);
        }
        #endregion

        #region GET CONSTRAINT
        //public void GetConstraint(int idPhase, int idPhaseState)
        //{
        //    InputControlPageViewModel inputControlPageViewModel = null;
        //    //GET LIST OF CONSTRAINT
        //    IList<PhasesConstraint> lstConstraints = blConstraints.GetConstraintsbyIdPhase(idPhase, idPhaseState);
        //    foreach (PhasesConstraint constraint in lstConstraints)
        //    {
        //        IList<ConstraintCondition> lstCondition = blConstraints.GetConditionByConstraints(constraint.IdPhaseConstraint);
        //        //int ct = 0;

        //        foreach (ConstraintCondition condition in lstCondition)
        //        {
        //            IList<bool> queryVerify = this.blGeneric.ExecuteSqlQuery<bool>(condition.QueryCondition);
        //            if (queryVerify[0] == true)
        //            {
        //                //int? inputControlId = this.blInputControl.GetBIInputControlId(Convert.ToInt32(condition.IdInputWizard));
        //                inputControlPageViewModel = this.blInputControl.GetDynamicPageControlModel("", this._sessionValue, condition.IdInputWizard);
        //                this.GetView(inputControlPageViewModel);
        //            }
        //            else
        //            {
        //                //this.LstPhaseCondition.Add(condition);
        //            }
        //        }
        //    }

        //}
        #endregion
    }
}
