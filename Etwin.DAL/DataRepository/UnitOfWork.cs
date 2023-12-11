using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model.Context;
using Org.BouncyCastle.Asn1.Crmf;

namespace Etwin.DAL.DataRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ETwinContext _db;

        //public IViewCommesseRepository ViewCommesse { get; private set; }
        public IGridsColumnsRepository GridsColumns { get; private set; }
        public IGridRepository Grid { get; private set; }
        public IChartRepository Chart { get; private set; }
        public ISchedulerRepository Scheduler { get; private set; }
        public ISchedulerAppointmentRepository SchedulerAppointments { get; private set; }
        public ISchedulerResourceRepository SchedulerResource { get; private set; }
        public ISchedulerDependencyRepository SchedulerDependency { get; private set; }
        public IChartSeriesRepository ChartSeries { get; private set; }
        public IGridBandRepository Band { get; private set; }
        public ISP_Call SP_Call { get; private set; }
        public IQUERY_Call QUERY_Call { get; private set; }
        public IRibbonPagesRepository RibbonPages { get; private set; }
        public IRibbonPageGroupsRepository RibbonPageGroups { get; private set; }
        public IRibbonPageGroupButtonsRepository RibbonPageGroupButtons { get; private set; }
        public ITimbratoreSetupRepository TimbratoreSetup { get; private set; }
        public IRangeClientRepository RangeClient { get; private set; }
        public IRangeAreaChartRepository RangeAreaChart { get; private set; }
        public IRangeRepository Range { get; private set; }
        public IGanttRepository Gantt { get; private set; }
        public IChartStripsRepository ChartStrips { get; private set; }
        public IChartPanesRepository ChartPanes { get; private set; }
        public IChartAnimationsRepository ChartAnimations { get; private set; }
        public ITimestepsRepository Timesteps { get; private set; }
        public IPhasesSequencesRepository PhasesSequences { get; private set; }
        public IProcessesListRepository ProcessesList { get; private set; }
        public IOperatorsCalendarRepository OperatorsCalendar { get; private set; }
        public IOperatorsRepository Operators { get; private set; }
        public IMacroProcessesRepository MacroProcesses { get; private set; }
        public IDeclarationValuesRepository DeclarationValues { get; private set; }
        public IDeclarationsRepository Declarations { get; private set; }
        public ICustomersRepository Customers { get; private set; }
        public IChartConstantLineRepository ChartConstantLine { get; private set; }
        public IChartAxisTitleRepository ChartAxisTitle { get; private set; }
        public IChartTitleRepository ChartTitle { get; private set; }
        public IDepartmentAccessRepository DepartmentAccess { get; private set; }
        public IItemsRepository Items { get; private set; }
        public IChartCrosshairRepository ChartCrosshair { get; private set; }
        public IGridTooltipRepository ToolTipGrid { get; private set; }
        public ISchedulerFlyoutAppointmentRepository SchedulerFlyoutAppointment { get; private set; }
        public IPhasesConstraintsRepository PhasesConstraints { get; private set; }
        public IConstraintConditionsRepository ConstraintConditions { get; private set; }
        public IPhasesListRepository PhasesList { get; private set; }
        public IAssignmentsRepository Assignments { get; private set; }
        public IKanBanGroupRepository KanBanGroup { get; private set; }
        public IKanBanItemRepository KanBanItem { get; private set; }
        public IKanBanBoardRepository KanBanBoard { get; private set; }
        public IInputWizardRepository InputWizard { get; private set; }
        public IInputStepWizardRepository InputStepWizard { get; private set; }
        public IInputControlRepository InputControl { get; private set; }
        public IEventRepository Event { get; private set; }
        public IEventLogRepository EventLog { get; private set; }
        public IPresenceDeclarationsRepository PresenceDeclarations { get; private set; }
        public ICompanyCalendarRepository CompanyCalendar { get; private set; }
        public IKpiRepository Kpi { get; private set; }
        public IKpiParametersRepository KpiParameters { get; private set; }
        public IItemValueRepository ItemValue { get; private set; }
        public IBomRepository Bom { get; private set; }
        public IOrderRowRepository OrderRow { get; private set; }
        public IOrdersRepository Orders { get; private set; }
        public IOrderValueRepository OrderValue { get; private set; }
        public IDeclarationsFutureRepository DeclarationsFuture { get; private set; }
        public IKcfPlannerRepository Kcf { get; private set; }
        public IProposalOrderRepository Proposal { get; private set; }
        public IWarehouseItemRepository WarehouseItem { get; private set; }
        public IBomPhasesRepository BomPhases { get; private set; }
        public IWarehouseMovementRepository WarehouseMovement { get; private set; }
        public ITrackRepository Track { get; private set; }
        public IPhasesCompanyRepository PhasesCompany { get; private set; }
        public IDocumentArchiveRepository DocumentArchive { get; private set; }
        public IDocumentArchiveValueRepository DocumentArchiveValue { get; private set; }
        public IItemGraphicComponentRepository ItemGraphicComponent { get; private set; }
        public ICompanyThemeRepository CompanyTheme { get; private set; }
        public IGeneralSettingActiveRepository GeneralSettingActive { get; private set; }
        public IItemParameterCompanyRepository ItemParameterCompany { get; private set; }
        public UnitOfWork(ETwinContext db)
        {
            this._db = db;
            this.GridsColumns = new GridsColumnsRepository(this._db);
            this.Grid = new GridRepository(this._db);
            this.Chart = new ChartRepository(this._db);
            this.Scheduler = new SchedulerRepository(this._db);
            this.SchedulerAppointments = new SchedulerAppointmentRepository(this._db);
            this.SchedulerResource = new SchedulerResourceRepository(this._db);
            this.SchedulerDependency = new SchedulerDependencyRepository(this._db);
            this.ChartSeries = new ChartSeriesRepository(this._db);
            this.Band = new GridBandRepository(this._db);
            this.SP_Call = new SP_Call(this._db);
            this.QUERY_Call = new QUERY_Call(this._db);
            this.RibbonPages = new RibbonPagesRepository(this._db);
            this.RibbonPageGroups = new RibbonPageGroupsRepository(this._db);
            this.RibbonPageGroupButtons = new RibbonPageGroupButtonsRepository(this._db);
            this.TimbratoreSetup = new TimbratoreSetupRepository(this._db);
            this.RangeClient = new RangeClientRepository(this._db);
            this.RangeAreaChart = new RangeAreaChartRepository(this._db);
            this.Range = new RangeRepository(this._db);
            this.Gantt = new GanttRepository(this._db);
            this.ChartStrips = new ChartStripsRepository(this._db);
            this.ChartPanes = new ChartPanesRepository(this._db);
            this.ChartAnimations = new ChartAnimationsRepository(this._db);
            this.Timesteps = new TimestepsRepository(this._db);
            this.PhasesSequences = new PhasesSequencesRepository(this._db);
            this.ProcessesList = new ProcessesListRepository(this._db);
            this.OperatorsCalendar = new OperatorsCalendarRepository(this._db);
            this.Operators = new OperatorsRepository(this._db);
            this.MacroProcesses = new MacroProcessesRepository(this._db);
            this.DeclarationValues = new DeclarationValuesRepository(this._db);
            this.Declarations = new DeclarationsRepository(this._db);
            this.Customers = new CustomersRepository(this._db);
            //this.ViewDepartmentOpenProcesses = new ViewDepartmentOpenProcessesRepository(this._db);
            this.ChartConstantLine = new ChartConstantLineRepository(this._db);
            this.ChartAxisTitle = new ChartAxisTitleRepository(this._db);
            this.ChartTitle = new ChartTitleRepository(this._db);
            this.DepartmentAccess = new DepartmentAccessRepository(this._db);
            this.Items = new ItemsRepository(this._db);
            this.ToolTipGrid = new GridTooltipRepository(this._db);
            this.ChartCrosshair = new ChartCrosshairRepository(this._db);
            this.SchedulerFlyoutAppointment = new SchedulerFlyoutAppointmentRepository(this._db);
            this.PhasesConstraints = new PhasesConstraintsRepository(this._db);
            this.ConstraintConditions = new ConstraintConditionsRepository(this._db);
            this.PhasesList = new PhasesListRepository(this._db);
            this.Assignments = new AssignmentsRepository(this._db);
            this.KanBanGroup = new KanBanGroupRepository(this._db);
            this.KanBanItem = new KanBanItemRepository(this._db);
            this.KanBanBoard = new KanBanBoardRepository(this._db);
            this.InputWizard = new InputWizardRepository(this._db);
            this.InputStepWizard = new InputStepWizardRepository(this._db);
            this.InputControl = new InputControlRepository(this._db);
            this.Event = new EventRepository(this._db);
            this.EventLog = new EventLogRepository(this._db);
            this.PresenceDeclarations = new PresenceDeclarationsRepository(this._db);
            this.CompanyCalendar = new CompanyCalendarRepository(this._db);
            this.Kpi = new KpiRepository(this._db);
            this.KpiParameters = new KpiParametersRepository(this._db);
            this.ItemValue = new ItemValueRepository(this._db);
            this.Bom = new BomRepository(this._db);
            this.Orders = new OrdersRepository(this._db);
            this.OrderRow = new OrdersRowRepository(this._db);
            this.OrderValue = new OrdersValueRepository(this._db);
            this.DeclarationsFuture = new DeclarationsFutureRepository(this._db);
            this.Kcf = new KcfPlannerRepository(this._db);
            this.Proposal = new ProposalOrderRepository(this._db);
            this.WarehouseItem = new WarehouseItemRepository(this._db);
            this.BomPhases = new BomPhasesRepository(this._db);
            this.WarehouseMovement = new WarehouseMovementRepository(this._db);
            this.Track = new TrackRepository(this._db);
            this.PhasesCompany = new PhasesCompanyRepository(this._db);
            this.DocumentArchive = new DocumentArchiveRepository(this._db);
            this.DocumentArchiveValue = new DocumentArchiveValueRepository(this._db);
            this.ItemGraphicComponent = new ItemGraphicComponentRepository(this._db);
            this.CompanyTheme = new CompanyThemeRepository(this._db);
            this.GeneralSettingActive = new GeneralSettingActiveRepository(this._db);
            this.ItemParameterCompany = new ItemParameterCompanyRepository(this._db);
        }

        public void Dispose()
        {
            this._db.Dispose();
        }

        public void Save()
        {
            this._db.SaveChanges();
        }
    }
}
