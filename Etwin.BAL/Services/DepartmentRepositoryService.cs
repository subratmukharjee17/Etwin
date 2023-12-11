using Etwin.DAL.DataRepository;
using Etwin.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using Etwin.Model;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.Context;
using System.Security.Cryptography;

namespace Etwin.BAL.Services
{
    public class DepartmentRepositoryService
    {
 
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;


        public DepartmentRepositoryService(/*IGenericRepository<Department> repository,
            IGenericRepository<RibbonsPage> repositoryRibbonsPage,
            IGenericRepository<RibbonsPageGroup> repositoryRibbonsPageGroup,
            IGenericRepository<DepartmentAccess> repositoryDepartmentAccess,
            IGenericRepository<RibbonsPageGroupButtons> repositoryRibbonsPageGroupButtons,
            IGenericRepository<ReportModeList> repositoryReportModelList,
            IGenericRepository<Bands> repositoryBands,
            IGenericRepository<GridsColumns> repositoryGridsColumns, IGenericRepository<Charts> repositoryChartSeries*/)
        {
            this._db = new ETwinContext();
            this.unitOfWork = new UnitOfWork(_db);
            //_repository = repository;
            //_repositoryRibbonsPage = repositoryRibbonsPage;
            //_repositoryRibbonsPageGroup = repositoryRibbonsPageGroup;
            //_repositoryDepartmentAccess = repositoryDepartmentAccess;
            //_repositoryRibbonsPageGroupButtons = repositoryRibbonsPageGroupButtons;
            //_repositoryReportModelList = repositoryReportModelList;
            //_repositoryBands = repositoryBands;
            //_repositoryGridsColumns = repositoryGridsColumns;
            //_repositoryChartSeries = repositoryChartSeries;
        }

        //public IList<Department> GetAll()
        //{
        //    IList<Department> model = _repository.GetAll().ToList();
        //    return model;
        //}

        //public Department GetById(int id)
        //{
            //return _repository.GetById(id);
        //}

        public void Delete(Department departmentId)
        {
            //this._db.Departments.Delete(departmentId);
            //_repository.Save();
        }

        //public IList<RibbonsPage> GetAllRibbonPage()
        //{
            //IList<RibbonsPage> model = _repositoryRibbonsPage.GetAll().ToList();
            //return model;
        //}

        public IList<Department> GetMenuByOpcode(string OpCode)
        {

            //IList<DepartmentInfo> model = (from dm in _repository.Table
            //                               join d in _repositoryDepartmentAccess.Table on dm.IdDepartment equals d.IdDepartment
            //                               where d.OperatorCode == OpCode
            //                               select new DepartmentInfo
            //                               {
            //                                   IdDepartment = dm.IdDepartment,
            //                                   Name = dm.Description
            //                               }).ToList();
            IList<Department> model = (from dm in _db.Departments
                                       join d in _db.DepartmentAccesses on dm.IdDepartment equals d.IdDepartment
                                       where d.OperatorCode == OpCode
                                       select dm).ToList();

            return model;
        }
        public IList<RibbonsPageGroup> GetByIdRibbonPage(int id)
        {

            //var query = from rpg in _repositoryRibbonsPageGroup.Table
            //            where rpg.IdRibbonPage == (from rp in _repositoryRibbonsPage.Table
            //                                       where rp.IdDepartment == id
            //                                       select rp.Id).FirstOrDefault()
            //            select rpg;
            //IList<RibbonsPageGroup> submenu = query.ToList();

            IList<RibbonsPageGroup> submenu = (from rpg in _db.RibbonsPageGroups
                                               where rpg.IdRibbonPage == (from rp in _db.RibbonsPages
                                                                          where rp.IdDepartment == id
                                                                          select rp.Id).FirstOrDefault()
                                               select rpg).ToList();

            return submenu;
        }
        //public RibbonsPage GetRibbonPageByIdMenu(int id)
        //{
        //    return _repositoryRibbonsPage.GetById(id);
        //}
        //public IList<RibbonsPageGroup> GetRibbonPageGroupById(int id)
        //{
        //    var query = from o in _repositoryRibbonsPageGroup.Table
        //                where o.IdRibbonPage == id

        //                select o;

        //    IList<RibbonsPageGroup> submenu = query.ToList();

        //    return submenu;
        //    //return _repositoryRibbonsPage.GetById(id);
        //}
        //public IList<RibbonsPageGroupButtons> RibbonsPageGroupButtonsById(int id)
        //{
        //    var query = from o in _repositoryRibbonsPageGroupButtons.Table
        //                where o.IdRibbonPageGroup == id
                         
        //                select o;

        //    IList<RibbonsPageGroupButtons> submenu = query.ToList();

        //    return submenu;
        //    //return _repositoryRibbonsPage.GetById(id);
        //}
        //public IList<RibbonsPageGroup> GetRibbonsPageGroupByIdBack(int id)
        //{
        //    var query = from x in _repositoryRibbonsPageGroup.Table
        //                where x.IdRibbonPage == (
        //                from d in _repositoryRibbonsPageGroup.Table
        //                where d.Id == id
        //                select d.IdRibbonPage).FirstOrDefault()
        //                select x;

        //    var submenu = query.ToList();

        //    return submenu;
        //    //return _repositoryRibbonsPage.GetById(id);
        //}
        //public IList<ReportChartModeList> ReportChartModel(string sqlQuery)
        //{
        //    var result = _repositoryReportModelList.ReportChartModel(sqlQuery);
        //    return result;
        //}
        //public IEnumerable<ReportOrderWithPhaseList> GetReportOrderPhaseDetails(string sqlQuery)
        //{
        //    var result = _repositoryReportModelList.ReportPhaseModel(sqlQuery).Take(500);
        //    return result;
        //}

        //public IEnumerable<ReportModeList> GetControlTypeAndQueryDetails(string storedproc, int id)
        //{
        //    var parameters = new object[]
        //    {
        //     id
        //    };
        //    var result = _repositoryReportModelList.GetControlTypeAndQueryDetails(storedproc, parameters);
        //    return result;
        //}
        //public IEnumerable<GridsColumns> GetReportBlackHeaderDetails(int Id)
        //{
        //    //var result = from column in _repositoryGridsColumns.Table
        //    //             join grid in _repositoryBands.Table on column.ID equals grid.ID
        //    //             where grid.IdGrid == 2
        //    //             select column;

        //    var result = _repositoryGridsColumns.Table
        //     .Join(_repositoryBands.Table.Where(grid => grid.IdGrid == Id), column => column.IDBand, grid => grid.ID, (column, grid) => column)
        //     .ToList();
        //    var submenu = result.ToList();

        //    return submenu;
        //}
        //public string GetChartName(int IdControl)
        //{
        //    var result = from chart in _repositoryChartSeries.Table
        //                 where chart.Id == IdControl
        //                 select chart.ChartName;
        //    return result.FirstOrDefault();
        //}
        //public IEnumerable<Bands> GetReportOrangeHeaderDetails(int Id)
        //{
        //    var query = from bands in _repositoryBands.Table
        //                where bands.IdGrid == Id
        //                select new Bands();
        //    var submenu = query.ToList();

        //    return submenu;
        //}

        //public RibbonsPage GetByIdRibbonPageBack(int id)
        //{
        //    var query =
        //        from rp in _repositoryRibbonsPage.Table
        //        where rp.Id == id
        //        select rp;
        //    var submenu = query;

        //    return submenu.FirstOrDefault();
        //    //return _repositoryRibbonsPage.GetById(id);
        //}
    }
}
