using Microsoft.AspNetCore.Mvc;
using LogDll;
using Etwin.Model;
using Etwin.BAL.BusinnessLogic;
using System.Dynamic;
using ETwin.BAL.FixModels;
using Etwin.DAL.Models;
using System.Text.RegularExpressions;
using Etwin.CLS.ConstraintsClass;
using ETwin.BAL;
using System.Xml.Linq;
using Etwin.Model.GlobalModels;
using Etwin.BAL.BusinnessLogic.BLGlobalDB;

namespace ETwin_Next.Controllers
{
    public class TimeBoundController : Controller
    {
        #region VARS
        IList<TimbratoreSetup> lvlTimbratore = new List<TimbratoreSetup>();
        TimbratoreSetup livelloDaCaricare = new TimbratoreSetup();
        private static readonly object lockObject = new object();
        private readonly BlTimbratoreSetup blTimbratoreSetup = null;
        private readonly BlDeclarations blDeclarations = null;
        private readonly BlOperators blOperators = null;
        private readonly BlPhasesCompany blPhases = null;
        private readonly BlPhase blPhaseGlobal = null;
        //private readonly BlConstraints blConstraints = null;
        private readonly BlGeneric blGeneric = null;
        private readonly BlInputControl blInputControl = null;
        public ExpandoObject modTimbratura = null;
        private readonly BlPresenceDeclarations blPresenceDeclarations = null;
        IList<modTimbratore> lstTimbratore = new List<modTimbratore>();
        string oldFilter = "phl.IdPhase = #IdFase#";
        string SqlQuery = String.Empty;
        IList<ItemContextButton> lstItemContextButtons = new List<ItemContextButton>();
        dynamic d = null;
        private readonly string _sessionValue;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly clsConstraints clsConstraints;
        #endregion

        #region CONSTRUCTOR
        public TimeBoundController(IHttpContextAccessor httpContextAccessor)
        {

            _httpContextAccessor = httpContextAccessor;
            _sessionValue = _httpContextAccessor.HttpContext.Session.GetString("cn");
            this.blTimbratoreSetup = new BlTimbratoreSetup(_sessionValue);
            this.blDeclarations = new BlDeclarations(_sessionValue);
            this.blOperators = new BlOperators(_sessionValue);
            this.blPhases = new BlPhasesCompany(_sessionValue);
            //this.blConstraints = new BlConstraints(_sessionValue);
            this.blPresenceDeclarations = new BlPresenceDeclarations(_sessionValue);
            this.blInputControl = new BlInputControl(_sessionValue);
            this.blGeneric = new BlGeneric(_sessionValue);
            this.blPhaseGlobal = new BlPhase();
        }

        #endregion

        #region OPERATOR (1° LVL)
        public IActionResult Operator(int idDepartment)

        {
            TimeBoundViewModel viewModel = new TimeBoundViewModel();
            try
            {
                //LEVEL TO LOAD
                this.livelloDaCaricare = this.blTimbratoreSetup.GetTimbratoreSetup(1);

                //REPLACE QUERY WITH PARAMETER
                this.SqlQuery = livelloDaCaricare.SqlQuery;
                this.SqlQuery = SqlQuery.Replace("#AMBITO", idDepartment.ToString());

                //EXECUTE QUERY
                viewModel.LstTimbratore = this.blTimbratoreSetup.ExecuteSqlQuery<ClsTimbratore>(this.SqlQuery, null, _sessionValue);

                //PARAMETER
                ViewBag.IdDepartment = idDepartment;

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return View(viewModel);
        }
        #endregion

        #region WORKPHASE (2° LVL)
        public IActionResult WorkPhase(int idDepartment, int idPhaseActivity, string operatorCode, string phaseState)
        {

            TimeBoundViewModel viewModel = new TimeBoundViewModel();
            try
            {

                //LEVEL TO LOAD
                this.livelloDaCaricare = blTimbratoreSetup.GetTimbratoreSetup(2);

                //REPLACE QUERY WITH PARAMETER
                this.SqlQuery = livelloDaCaricare.SqlQuery;
                this.SqlQuery = SqlQuery.Replace("#AMBITO", idDepartment.ToString());

                //EXECUTE QUERY
                viewModel.LstTimbratore = blTimbratoreSetup.ExecuteSqlQuery<ClsTimbratore>(this.SqlQuery, null, _sessionValue);

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return View(viewModel);
        }
        #endregion

        #region ORDERS (3° LVL)
        public IActionResult Orders(string operatorCode, string phaseCode, int idPhaseState, int idPhaseActivity)
        {
            TimeBoundViewModel viewModel = new TimeBoundViewModel();
            try
            {
                PhasesCompany phasesCompany = new PhasesCompany();
                if (blPhases != null)
                {
                    //GET PHASE COMPANY
                    phasesCompany = blPhases.GetPhaseFromCode(phaseCode);
                }
                //if (Request.Query.TryGetValue("PhaseState", out var PhaseState))
                //{
                //    //GET PHASE STATE
                //    ViewBag.PhaseState = PhaseState;
                //}
                if (phasesCompany != null)
                {
                    //GET LEVEL TO LOAD
                    this.livelloDaCaricare = blTimbratoreSetup.GetTimbratoreSetup(3);

                    //REPLACE QUERY WITH PARAMETER
                    this.SqlQuery = livelloDaCaricare.SqlQuery;
                    this.SqlQuery = SqlQuery.Replace(" #IDPHASE#", phasesCompany.Id.ToString());

                    //EXECUTE QUERY
                    viewModel.LstTimbratore = blTimbratoreSetup.ExecuteSqlQuery<ClsTimbratore>(this.SqlQuery, null, _sessionValue);

                    //PARAMETERS
                    //TempData["Operator"] = operatorCode;
                    TempData["PhaseId"] = phasesCompany.Id;
                    //TempData["PhaseStateId"] = idPhaseState.ToString();
                    //TempData["QueryTimebound"] = viewModel.LstTimbratore;
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return View(viewModel);

        }
        #endregion

        #region GetLoadingLevel
        private IList<modTimbratore> GetLoadingLevel()
        {
            try
            {
                //CICLO PER LA LISTA E SALVO IL LIVELLO DA CARICARE
                foreach (TimbratoreSetup ts in this.lvlTimbratore)
                {
                    if (ts.PageName == "Operatori")
                    {
                        this.livelloDaCaricare = ts;
                        var query = ts.SqlQuery;
                        break;
                    }
                    else
                    {
                        this.livelloDaCaricare = ts;
                        break;
                    }
                }
                var qry = livelloDaCaricare.SqlQuery.Replace("#AMBITO", "1");
                this.SqlQuery = qry;
                lstTimbratore = blTimbratoreSetup.ExecuteSqlQuery<modTimbratore>(this.SqlQuery, null, _sessionValue);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstTimbratore;
        }
        #endregion

        #region UPDATE OPERATORS STATE

        public void UpdateOperatorsState(string operatorCode, int idPhaseState, int IdPresenceState)
        {
            /* ID PRESENCE STATE DETAIL 
             * Negli operatori l'IdPresenceState assumerà i seguenti valori:
             * IdPresenceState = 1 (Stopped) || IdPresenceState = 3 (Unavailable)

             * Nelle timbrature di presenza assumerà valori 
             * IdPresenceState = 1 (Entry) || IdPresenceState = 2 (Exit)

             * I valori possono essere dati a mano dato che sarà una regola fissa del software

             * __________________________________________________________________________________________________
             * In the operators the IdPresenceState will take on the following values:
             * IdPresenceState = 1 (Stopped) || IdPresenceState = 3 (Unavailable)

             * In the attendance stamps it will take on values
             * IdPresenceState = 1 (Entry) || IdPresenceState = 2 (Exit)

             * The values ​​can be given manually as it will be a fixed rule of the software*/
            try
            {
                BlLogin blLogin = new BlLogin();
                string pattern = @"\d{2}\.\d{2}\.\d{2}";
                Match match = Regex.Match(operatorCode, pattern);

                if (match.Success)
                {
                    operatorCode = match.Value;

                }
                if (operatorCode != null)
                {
                    Etwin.Model.Operator op = blLogin.GetOperatorFromCode(operatorCode, _sessionValue);
                    if (idPhaseState == 0 && IdPresenceState == 1)
                    {
                        //Operatore timbra presenza [Operator clocks in]
                        op.IdOperatorState = IdPresenceState;
                    }
                    else if (idPhaseState == 0 & IdPresenceState == 2)
                    {
                        //Operatore timbra uscita [Operator clocks out]
                        op.IdOperatorState = 3;
                    }


                    //Get Last operator declaration
                    Declaration d = blDeclarations.GetWorkingPhaseDeclaration(operatorCode);

                    //Controllo se ho riferimento della presenza
                    if (IdPresenceState == 0)
                    {
                        //Non timbro presenza
                        //Controllo se la fase è terminata o sopesa (dato che le attività di fase non possono terminare)
                        if (d.IdPhaseState == 3 || d.IdPhaseState == 2)
                        {
                            //Fase terminata o sospesa
                            Console.WriteLine("Fase sospesa o terminata");

                            //Operatore fermo
                            op.IdOperatorState = 1;
                        }
                        else
                        {
                            /* WorkPhase in activity 
                             * The case numbers (case 1, case 5,...) are linked to the id of the PhaseStates table and must correspond to a specific operator state (OperatorStates).
                             * If the id changes the procedure does not work.
                             */
                            if (idPhaseState == 1)
                            {
                                op.IdOperatorState = 2;
                            }
                            else
                            {
                                op.IdOperatorState = 1;
                            }
                        }
                    }
                    else
                    {
                        //Timbro la presenza
                        AddPresenceDeclarations(operatorCode, DateTime.Now, IdPresenceState);
                    }

                    blOperators.UpdateOperatore(op);

                }

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        #endregion

        #region GetOperatorState
        public JsonResult GetOperatorState(string operatorCode)
        {
            string tilecolor = "";

            try
            {
                if (!string.IsNullOrEmpty(operatorCode))
                {
                    //GET MODEL OPERATOR BY OPERATOR CODE
                    Etwin.Model.Operator op = this.blOperators.GetOperatorFromCode(operatorCode);
                    //CHECK THE STATE OF OPERATOR

                    //OPRATOR IS WORKING
                    //GET LAST DECLARATION TO CHECK THE PHASE ACTIVITY
                    Declaration d = this.blDeclarations.GetWorkingPhaseDeclaration(operatorCode);
                    if (d.IdPhaseActivity == 1)
                    {
                        //PROCESSING
                        tilecolor = "limegreen";
                    }
                    else if (d.IdPhaseActivity == 2)
                    {
                        //EQUIPMENT
                        tilecolor = "orange";
                    }
                    else if (d.IdPhaseActivity == 3)
                    {
                        //PREPARATION
                        tilecolor = "darkgreen";
                    }
                    else if (d.IdPhaseActivity == 4)
                    {
                        //MOVEMENT
                        tilecolor = "purple";
                    }

                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return Json(tilecolor);

        }
        #endregion

        /*#region SET DECLARATION VALUE PARAMETER
        public void SetDeclarationValueParameter(Declaration d)
        {
            try
            {
                using (BlDeclarationParameters blDeclarationParameters = new BlDeclarationParameters())
                {
                    IList<DeclarationValue> lstValori = new List<DeclarationValue>();
                    IList<DeclarationParameter> lstparameter = blDeclarationParameters.GetAllDeclarationParameter();
                    foreach (DeclarationParameter dp in lstparameter)
                    {
                        foreach (KeyValuePair<string, object> keyValueDynamicModel in this.modTimbratura)
                        {
                            if (dp.DeclarationParameters == keyValueDynamicModel.Key)
                            {
                                if (!string.IsNullOrEmpty(keyValueDynamicModel.Value.ToString()))
                                {
                                    DeclarationValue declarationValue = new DeclarationValue();
                                    declarationValue.IdDeclarationParameters = dp.IdDeclarationParameter;
                                    declarationValue.DeclarationValue1 = keyValueDynamicModel.Value.ToString();
                                    declarationValue.IdDeclarations = d.IdDeclaration;

                                    using (BlDeclarationValues blDeclarationValues = new BlDeclarationValues())
                                    {
                                        blDeclarationValues.AddDeclarationValue(declarationValue);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        #endregion*/

        #region DECLARATION

        #region ADD PRODUCTIVE DECLARATION
        public void AddDeclarations(string operatorCode = null, string idPhaseActivity = null, string idPhase = null, string idPhaseState = null, string IdProcessList = null)
        {
            bool canGoOn = false;

            string pattern = @"\d{2}\.\d{2}\.\d{2}";
            if (operatorCode != null)
            {
                Match match = Regex.Match(operatorCode, pattern);

                if (match.Success)
                {
                    operatorCode = match.Value;

                }
            }

            /*Evaluate the phase
             *If phase is productive, continue this method
             *else go to "AddNotProductiveDeclarations" method
             */

            //Get phase company



            //Get last declaration of operator
            Declaration d = blDeclarations.GetWorkingPhaseDeclaration(operatorCode);
            //Check if there is already a declaration for this operator
            PhasesCompany pc = null;
            if(idPhase!= null)
            {
                pc = this.blPhases.GetPhaseCompanyById(int.Parse(idPhase));

            }
            else
            {
                pc = this.blPhases.GetPhaseCompanyById(d.IdPhaseCompany);
                idPhase = d.IdPhaseCompany.ToString();

            }
            Phase p = this.blPhaseGlobal.GetPhase(pc.IdPhase);

            if (p.IdPhaseType == 1)
            {
                Declaration declaration = new Declaration();
                int idPhaseStateCast = int.Parse(idPhaseState);
                int IdPhaseCast = 0;
                int idPhaseActivityCast = int.Parse(idPhaseActivity);
                if (d.IdPhaseState != 2 && d.IdPhaseState != 3)
                {
                    //The last phase isn't Stopped or Finished
                    if (idPhaseStateCast != 2 && idPhaseStateCast != 3)
                    {
                        //I want to change activity, so the phase will not be Stopped or Finished

                        //Stop old declaration
                        Declaration declarationToStop = new Declaration()
                        {
                            OperatorCode = d.OperatorCode,
                            IdPhaseState = 2,
                            IdPhaseActivity = idPhaseActivityCast,
                            IdProcessList = d.IdProcessList,
                            DeclarationDate = DateTime.Now,
                            IdPhaseCompany = d.IdPhaseCompany,
                        };

                        /*ANALISI VINCOLI*/
                        IdPhaseCast = d.IdPhaseCompany;

                        this.RedirectToPopup(IdPhaseCast, idPhaseStateCast);

                        this.blDeclarations.AddDeclarations(declarationToStop);

                        //Create new Declaration for the new activity
                        declaration.OperatorCode = operatorCode;
                        declaration.IdPhaseState = idPhaseStateCast;
                        declaration.IdPhaseActivity = idPhaseActivityCast;
                        declaration.IdProcessList = d.IdProcessList;
                        declaration.DeclarationDate = DateTime.Now;
                        declaration.IdPhaseCompany = d.IdPhaseCompany;
                    }
                    else
                    {
                        declaration.OperatorCode = operatorCode;
                        declaration.IdPhaseState = idPhaseStateCast;
                        declaration.IdProcessList = d.IdProcessList;
                        declaration.IdPhaseActivity = idPhaseActivityCast;
                        declaration.DeclarationDate = DateTime.Now;
                        declaration.IdPhaseCompany = d.IdPhaseCompany;
                    }

                }
                else if (!string.IsNullOrEmpty(IdProcessList) && !string.IsNullOrEmpty(operatorCode) && !string.IsNullOrEmpty(idPhaseState) && !string.IsNullOrEmpty(idPhase))
                {
                    IdPhaseCast = int.Parse(idPhase);
                    declaration.OperatorCode = operatorCode;
                    declaration.IdPhaseState = idPhaseStateCast;
                    declaration.IdPhaseActivity = idPhaseActivityCast;
                    declaration.IdProcessList = int.Parse(IdProcessList);
                    declaration.DeclarationDate = DateTime.Now;
                    declaration.IdPhaseCompany = IdPhaseCast;
                }
                else
                {
                    IdPhaseCast = d.IdPhaseCompany;
                }

                /*ANALISI VINCOLI*/

                if (declaration.IdProcessList != null && !string.IsNullOrEmpty(declaration.OperatorCode) && declaration.IdPhaseState != null && declaration.IdPhaseCompany != null)
                {
                    this.RedirectToPopup(IdPhaseCast, idPhaseStateCast);
                    this.blDeclarations.AddDeclarations(declaration);
                }
            }
            else
            {
                this.AddNotProductiveDeclarations(operatorCode, idPhaseActivity, idPhase, idPhaseState, IdProcessList);
            }

        }
        #endregion

        #region ADD NOT PRODUCTIVE DECLARATION
        public void AddNotProductiveDeclarations(string operatorCode = null, string idPhaseActivity = null, string idPhase = null, string idPhaseState = null, string IdProcessList = null)
        {
            try
            {
                if (idPhaseState.Equals("3"))
                {
                    idPhaseState = "2";
                }
                Declaration d = new Declaration()
                {
                    OperatorCode = operatorCode,
                    IdPhaseState = int.Parse(idPhaseState),
                    IdPhaseActivity = int.Parse(idPhaseActivity),
                    IdProcessList = null,
                    IdPhaseCompany = int.Parse(idPhase),
                    DeclarationDate = DateTime.Now
                };
                this.blDeclarations.AddDeclarations(d);

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        #endregion

        #endregion


        #region GET CONSTRAINTS
        public void RedirectToPopup(int idPhase, int idPhaseState)
        {
            InputControlPopupController icpc = new InputControlPopupController(this._httpContextAccessor);
            //icpc.GetConstraint(idPhase, idPhaseState);
            //return RedirectToAction("Index", "InputControlPopup", new { IdFase = idPhase, IdStatoFase = idPhaseState });
        }
        #endregion

        #region AddPresenceDeclarations
        public void AddPresenceDeclarations(string OperatorCode, DateTime DeclaratinTime, int idPhaseState)
        {
            PresenceDeclaration presenceDeclarations = new PresenceDeclaration();
            presenceDeclarations.OperatorCode = OperatorCode;
            presenceDeclarations.IdPresenceState = idPhaseState;
            presenceDeclarations.DeclarationDate = DeclaratinTime;

            this.blPresenceDeclarations.AddDeclaration(presenceDeclarations);
        }
        #endregion

        #region GetDeclarations
        public void GetDeclarations(string operatorCode, string tileColor, int idPhaseState)
        {
            string OperatorValue = null;

            string pattern = @"\d{2}\.\d{2}\.\d{2}";
            Match match = Regex.Match(operatorCode, pattern);

            if (match.Success)
            {
                OperatorValue = match.Value;

            }
            Declaration declaration = new Declaration();
            this.blDeclarations.GetDeclaration(1);

        }
        #endregion

        #region GetPhase
        public IActionResult GetPhase(string phaseCode)
        {
            PhasesCompany p = new PhasesCompany();
            try
            {
                p = this.blPhases.GetPhaseFromCode(phaseCode);
            }
            catch (Exception e)
            {
                clsLog.Error(e.ToString());
            }
            return Json(p);
        }
        #endregion

    }
}