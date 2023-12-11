using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.Linq.Expressions;
using LogDll;
using Etwin.Model.Context;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlEvent : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlEvent(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        public Event GetEvent(int id)
        {
            Event eventDescription = new Event();
            try
            {
                Expression<Func<Event, bool>> expr = e => e.Id == id;
                eventDescription = this.unitOfWork.Event.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return eventDescription;
        }
        public IList<Event> GetAllEvents()
        {
            IList<Event> lstEvent = new List<Event>();
            try
            {
                //Expression<Func<Event, bool>> expr = e => e.Id == id;
                lstEvent = this.unitOfWork.Event.GetAll().ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstEvent;
        }

        public DateTime GetLastTimeEventLog(int idEvent, int esito)
        {
            DateTime date = new DateTime();
            IList<EventLog> lst = null;
            try
            {
                Expression<Func<EventLog, bool>> expr = e => e.IdEvent == idEvent && e.IdEventState == esito;
                lst = this.unitOfWork.EventLog.GetAll(expr).ToList();
                foreach (EventLog e in lst.OrderByDescending(g => g.StartDate))
                {
                    if (e.EndDate != null)
                    {
                        date = (DateTime)e.EndDate;
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return date;
        }

        public async Task<EventLog> GetEventLogInEsecuzione(int idEvent, int esito)
        {
            EventLog eventLog = null;
            try
            {
                Expression<Func<EventLog, bool>> expr = e => e.IdEvent == idEvent && e.IdEventState == esito;
                eventLog = this.unitOfWork.EventLog.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return eventLog;
        }

        public async Task<EventLog> GetLastEventDesc(int idEvent, int esito)
        {
            EventLog eventLog = null;
            try
            {

                Expression<Func<EventLog, bool>> expr = e => e.IdEvent == idEvent && e.IdEventState == esito;
                eventLog = this.unitOfWork.EventLog.GetAll(expr, null, null).OrderByDescending(x => x.EndDate).FirstOrDefault();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return eventLog;
        }

        public IList<object> GetMethodParameters(string queryParameter)
        {
            IList<object> parameters = new List<object>();
            try
            {
                using (BlGeneric blGeneric = new BlGeneric())
                {
                    parameters = blGeneric.ExecuteSqlQuery<object>(queryParameter);
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return parameters;
        }

        public async Task UpdateEventLog(EventLog log,string cs)
        {
            try
            {
                await this.unitOfWork.EventLog.UpdateAsync(log, cs);

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public void AddEventLog(EventLog log)
        {
            try
            {
                this.unitOfWork.EventLog.Add(log);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }


        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
