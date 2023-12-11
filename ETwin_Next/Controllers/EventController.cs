using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using LogDll;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;
using Etwin.DAL.DataRepository;
using Etwin.Model.Context;
using System.Configuration;
using Etwin.CLS.EventHelper;

namespace Etwin.BAL.ControllersEtwin
{

    public class EventController : Controller
    {
        #region VARS
        private readonly clsEvent EventClass = null;
        private ETwinContext _db;
        private readonly BlEvent blEvent = null;
        private readonly BlGeneric blGeneric = null;
        private readonly string _sessionValue;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region CONSTRUCTOR
        public EventController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _sessionValue = _httpContextAccessor.HttpContext.Session.GetString("cn");
            this.blEvent = new BlEvent(_sessionValue);
            this.blGeneric = new BlGeneric(_sessionValue);
            this.EventClass = new clsEvent();
        }
        #endregion

        #region INDEX
        [HttpGet]
        public IActionResult Index()
        {
            var data = TempData["Key"];
            TempData.Keep("Key");
            return View();
        }
        #endregion

        #region GET LAST TIME EVENT LOG
        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetLastTimeEventLog/{idEvent}/{esito}")]
        public async Task<DateTime> GetLastTimeEventLog(int idEvent, int esito)
        {
            DateTime date = new DateTime();
            try
            {
                date = this.blEvent.GetLastTimeEventLog(idEvent, esito);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return date;
        }
        #endregion

        #region GET EVENT LOG IN EXECUTION
        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetEventLogInEsecuzione/{idEvent}/{esito}")]
        public async Task<EventLog> GetEventLogInEsecuzione(int idEvent, int esito)
        {
            EventLog eventLog = new EventLog();
            try
            {
                eventLog = await this.blEvent.GetEventLogInEsecuzione(idEvent, esito);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return eventLog;
        }
        #endregion

        #region UPDATE EVENT LOG
        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateEventLog/{log}")]
        public async Task UpdateEventLog(EventLog log)
        {
            try
            {
                await this.blEvent.UpdateEventLog(log, _sessionValue);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        #endregion

        #region ADD EVENT LOG
        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddEventLog/{log}")]
        public void AddEventLog(EventLog log)
        {
            try
            {
                this.blEvent.AddEventLog(log);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        #endregion

        #region GET LAST EVENT DESC
        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetEventLogInEsecuzione/{idEvent}/{esito}")]
        public async Task<EventLog> GetLastEventDesc(int idEvent, int esito)
        {
            EventLog eventLog = new EventLog();
            try
            {
                eventLog = await this.blEvent.GetLastEventDesc(idEvent, esito);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return eventLog;
        }
        #endregion

        #region GET EVENT
        public async Task GetEvent()
        {
            try
            {
                //Get all events
                IList<Event> lstEvent = this.blEvent.GetAllEvents();

                foreach (Event e in lstEvent.OrderBy(x => x.Order))
                {
                    #region CAN EVENT START?
                    //Check if the active event is still running
                    EventLog runningLog = await this.blEvent.GetEventLogInEsecuzione(e.Id, 2);
                    if (runningLog != null)
                        if (runningLog.IdEventState == 2 && runningLog.StartDate < DateTime.Now.AddHours(-2))
                        {
                            runningLog.IdEventState = 3;
                            this.UpdateEventLog(runningLog);

                        }

                    //Check if the indicated minutes have passed to be able to run again the event.
                    EventLog lastLog = await this.blEvent.GetLastEventDesc(e.Id, 1);

                    DateTime newEventEstimatedStartedTime = new DateTime();
                    if (lastLog != null)
                    {
                        TimeSpan ExecutionTime = TimeSpan.FromMinutes(e.ExecPeriodInMinutes);
                        newEventEstimatedStartedTime = ((DateTime)lastLog.EndDate).Add(ExecutionTime);
                    }
                    #endregion


                    if (runningLog == null && DateTime.Now > newEventEstimatedStartedTime)
                    {
                        //I can execute the method

                        //Check if there are parameters

                        #region ANALYSIS PARAMETER

                        IList<KeyValuePair<string, string>> eventParameters = new List<KeyValuePair<string, string>>();
                        if (e.ParameterQuery != null)
                        {
                            eventParameters = blGeneric.ExecuteSqlQuery<KeyValuePair<string, string>>(e.ParameterQuery);
                        }
                        if (e.ClassName != null)
                        {
                            //Find Method
                            this.EventClass.RunMethod(e.ClassName, e.MethodName, eventParameters);
                        }
                        #endregion

                        bool success = true;

                        //Check if there is a method or a stored procedure
                        if (e.ClassName != null)
                        {
                            #region IS METHOD
                            Task.Run(async () =>
                            {
                                while (success)
                                {
                                    EventLog rl = await this.blEvent.GetEventLogInEsecuzione(e.Id, 2);

                                    //Check if the indicated minutes have passed to be able to run again the event.
                                    EventLog ll = await this.blEvent.GetLastEventDesc(e.Id, 1);

                                    DateTime newEvent = new DateTime();
                                    if (ll != null)
                                    {
                                        TimeSpan et = TimeSpan.FromMinutes(e.ExecPeriodInMinutes);
                                        newEvent = ((DateTime)ll.EndDate).Add(et);
                                    }
                                    if (rl == null && DateTime.Now > newEvent)
                                    {


                                        EventLog el = new EventLog()
                                        {
                                            IdEvent = e.Id,
                                            IdEventState = 2,
                                            StartDate = DateTime.Now
                                        };
                                        this.AddEventLog(el);
                                        success = await this.ProcessEventMethodAsync(this.EventClass.Method, this.EventClass.ClassInstance, this.EventClass.Parameters);
                                        if (success)
                                        {
                                            el.IdEventState = 1;
                                        }
                                        else
                                        {
                                            el.IdEventState = 3;
                                        }
                                        el.EndDate = DateTime.Now;


                                        this.UpdateEventLog(el);


                                        await Task.Delay(TimeSpan.FromMinutes(e.ExecPeriodInMinutes));
                                    }
                                }
                            });
                            #endregion
                        }
                        else
                        {
                            #region IS STORED PROCEDURE
                            Task.Run(async () =>
                            {
                                while (success)
                                {
                                    EventLog rl = await this.blEvent.GetEventLogInEsecuzione(e.Id, 2);

                                    //Check if the indicated minutes have passed to be able to run again the event.
                                    EventLog ll = await this.blEvent.GetLastEventDesc(e.Id, 1);

                                    DateTime newEvent = new DateTime();
                                    if (ll != null)
                                    {
                                        TimeSpan et = TimeSpan.FromMinutes(e.ExecPeriodInMinutes);
                                        newEvent = ((DateTime)ll.EndDate).Add(et);
                                    }
                                    if (rl == null && DateTime.Now > newEvent)
                                    {
                                        EventLog el = new EventLog()
                                        {
                                            IdEvent = e.Id,
                                            IdEventState = 2,
                                            StartDate = DateTime.Now
                                        };
                                        this.AddEventLog(el);
                                        success = this.RunStoredProcedure(e.ProcedureName, eventParameters);
                                        if (success)
                                        {
                                            el.IdEventState = 1;
                                        }
                                        else
                                        {
                                            el.IdEventState = 3;
                                        }
                                        el.EndDate = DateTime.Now;

                                        this.UpdateEventLog(el);


                                        await Task.Delay(TimeSpan.FromMinutes(e.ExecPeriodInMinutes));
                                    }
                                }
                            });
                            #endregion
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }
        #endregion

        #region RUN STORED PROCEDURE
        private bool RunStoredProcedure(string procedureName, IList<KeyValuePair<string, string>> eventParameters)
        {
            bool esito = false;

            try
            {
                this._db = new ETwinContext(_sessionValue);
                using (SP_Call sp = new SP_Call(this._db))
                {
                    //Check if there are some parameters
                    Dapper.DynamicParameters dP = new Dapper.DynamicParameters();
                    foreach (KeyValuePair<string, string> ep in eventParameters)
                    {
                        dP.Add(ep.Key, ep.Value);
                    }
                    string procedureJson = sp.OneRecordJson(procedureName, dP);
                    esito = true;
                }
            }
            catch (Exception ex)
            {
                esito = false;
                clsLog.Error(ex.ToString());
            }
            return esito;
        }
        #endregion

        #region ASYNC RUN METHOD
        public async Task<bool> ProcessEventMethodAsync(MethodInfo method, object classInstance, object[] o)
        {
            bool esito = false;
            try
            {
                if (method != null)
                {
                    if (o.Count() > 0)
                    {
                        await Task.Run(() => method.Invoke(classInstance, new object[] { o }));
                    }
                    else
                    {
                        await Task.Run(() => method.Invoke(classInstance, new object[] { }));
                    }
                    esito = true;
                }
                else
                {
                    esito = false;
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return esito;
        }
        #endregion


    }
}