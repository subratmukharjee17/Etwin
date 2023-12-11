using Etwin.Model;
using Microsoft.AspNetCore.Mvc;
using Etwin.BAL.BusinnessLogic;
using Etwin.DAL.Models;
using LogDll;


namespace ETwin_Next.Controllers
{
    public class SchedularController : Controller
    {
        Scheduler clsScheduler = null;
        int IdScheduler = 0;
        private readonly BlSchedulers blSchedulers = null;
        private BlGeneric blGeneric = null;
        private BlSchedulerAppointment blSchedulerAppointment = null;
        private BlSchedulerResource blSchedulerResource = null;
        public SchedularController()
        {
            this.blSchedulers = new BlSchedulers();
            this.blGeneric = new BlGeneric();
            this.blSchedulerAppointment = new BlSchedulerAppointment();
            this.blSchedulerResource = new BlSchedulerResource();
        }

        public IActionResult OperatorsCalendar(int idSched)
        {
            SchedularViewModel schedularViewModel = new SchedularViewModel();
            idSched = 5;
            clsScheduler = blSchedulers.GetScheduler(idSched);
            IList<DateTime> rngMin = this.blGeneric.ExecuteSqlQuery<DateTime>(clsScheduler.StartDate);
            IList<DateTime> rngMax = this.blGeneric.ExecuteSqlQuery<DateTime>(clsScheduler.EndDate);


            IList<SchedulerAppointmentMapping> lstAppointment = this.blSchedulerAppointment.GetSchedulerAppointment(idSched);

            foreach (SchedulerAppointmentMapping item in lstAppointment)
            {
                schedularViewModel.ClsschedulerAppointmentMapping = this.blGeneric.ExecuteSqlQuery<SchedulerAppointmentMapping>(item.QueryDatasource);
            }

            IList<SchedulerResourceMapping> lstResource = this.blSchedulerResource.GetSchedulerResources(idSched);
            foreach (SchedulerResourceMapping srm in lstResource)
            {
                schedularViewModel.ClsschedulerResourceMapping = this.blGeneric.ExecuteSqlQuery<SchedulerResourceMapping>(srm.QueryDatasource);
            }
            return View(schedularViewModel);
        }
    }
}
