using Etwin.BAL.BusinnessLogic;
using Etwin.Model;

namespace Etwin.CLS.ConstraintsClass
{
    public class clsConstraints
    {
        #region VARS
        private readonly BlPhaseConstraints blConstraints = null;
        private readonly BlGeneric blGeneric = null;
        private readonly BlInputControl _blInputControl = null;
        public IList<ConstraintCondition> LstPhaseCondition = new List<ConstraintCondition>();
        private string connectionString = String.Empty;
        private readonly IServiceProvider _serviceProvider;

        #endregion

        #region PROPERTIES
        public IList<ConstraintCondition> lstPhasesCondition
        {
            get { return this.LstPhaseCondition; }
            set { this.LstPhaseCondition = value; }
        }
        #endregion

        #region CONSTRUCTOR
        public clsConstraints(string cs = null, IServiceProvider serviceProvider = null)
        {
            this.connectionString = cs;
            this.blConstraints = new BlPhaseConstraints(cs);
            this.blGeneric = new BlGeneric(cs);
            this._blInputControl = new BlInputControl(cs);
            _serviceProvider = serviceProvider;
        }
        #endregion

        //public bool CheckConstraints(int idPhase, int idPhaseState)
        //{
        //    bool isVerify = false;
        //    try
        //    {
        //        IList<PhasesConstraint> lstConstraints = blConstraints.GetConstraintsbyIdPhase(idPhase, idPhaseState);
        //        foreach (PhasesConstraint constraint in lstConstraints)
        //        {
        //            IList<ConstraintCondition> lstCondition = blConstraints.GetConditionByConstraints(constraint.IdPhaseConstraint);
        //            //int ct = 0;

        //            foreach (ConstraintCondition condition in lstCondition)
        //            {
        //                IList<bool> queryVerify = this.blGeneric.ExecuteSqlQuery<bool>(condition.QueryCondition);
        //                if (queryVerify[0] == true)
        //                {
        //                    this.GetInputControl(condition.IdInputWizard);
        //                }
        //                else
        //                {
        //                    //this.LstPhaseCondition.Add(condition);
        //                }
        //            }
        //            //if (ct == lstCondition.Count)
        //            //{
        //            //    isVerify = true;
        //            //}
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        clsLog.Error(ex.ToString());
        //    }
        //    return isVerify;
        //}

        #region ALERT CONSTRAINT
        //public bool AlertConstraint(int idPhase, int idPhaseState)
        //{
        //    bool isVerify = false;
        //    try
        //    {
        //        //isVerify = this.CheckConstraints(idPhase, idPhaseState);
        //        if (isVerify == false)
        //        {
        //            foreach (ConstraintCondition condition in this.LstPhaseCondition)
        //            {
        //                //IList<PhasesOutputAction> lstAction = blConstraints.GetActionByCondition(condition.IdPhaseCondition);
        //                //foreach (PhasesOutputAction action in lstAction)
        //                //{
        //                //ESEGUO LE AZIONI CHE SI TROVANO IN action
        //                //}
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLog.Error(ex.ToString());
        //    }
        //    return isVerify;
        //}
        #endregion

        //public IActionResult GetInputControl(int menuId)
        //{
           
        //    try
        //    {
        //        int? inputControlId = this._blInputControl.GetBIInputControlId(Convert.ToInt32(menuId));
        //        InputControlPageViewModel inputControlPageViewModel = this._blInputControl.GetDynamicPageControlModel("", this.connectionString, inputControlId);

        //        var viewResult = new ViewResult
        //        {
        //            ViewName = "InputControl", // Sostituisci con il nome della tua vista
        //            ViewData = new ViewDataDictionary<InputControlPageViewModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary())
        //            {
        //                Model = inputControlPageViewModel // Imposta il modello della vista
        //            }
        //        };

        //        var executor = _serviceProvider.GetRequiredService<IActionResultExecutor<ViewResult>>();

        //        var routeData = new Microsoft.AspNetCore.Routing.RouteData();
        //        routeData.Values["controller"] = "YourController"; // Sostituisci con il nome del tuo controller
        //        routeData.Values["action"] = "YourAction"; // Sostituisci con il nome dell'azione del tuo controller

        //        var actionContext = new ActionContext(new DefaultHttpContext(), routeData, new ActionDescriptor());

        //        return Task.Run(async () => await executor.ExecuteAsync(actionContext, viewResult)).Result;
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLog.Error(ex.ToString());
        //    }
        //}
    }
}
