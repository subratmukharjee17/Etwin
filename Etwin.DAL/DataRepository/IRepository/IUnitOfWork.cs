using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        //IViewCommesseRepository ViewCommesse { get; }
        IGridsColumnsRepository GridsColumns { get; }
        IGridRepository Grid { get; }
        IChartRepository Chart { get; }
        ISchedulerRepository Scheduler { get; }
        ISchedulerAppointmentRepository SchedulerAppointments { get; }
        ISchedulerResourceRepository SchedulerResource { get; }
        ISchedulerDependencyRepository SchedulerDependency { get; }
        IChartSeriesRepository ChartSeries { get; }
        IGridBandRepository Band { get; }
        ISP_Call SP_Call { get; }
        IQUERY_Call QUERY_Call { get; }
        IRibbonPagesRepository RibbonPages { get; }
        IRibbonPageGroupsRepository RibbonPageGroups { get; }
        IRibbonPageGroupButtonsRepository RibbonPageGroupButtons { get; }
        ITimbratoreSetupRepository TimbratoreSetup { get; }
        IRangeClientRepository RangeClient { get; }
        IRangeAreaChartRepository RangeAreaChart { get; }
        IRangeRepository Range { get; }
        IGanttRepository Gantt { get; }
        IChartStripsRepository ChartStrips { get; }
        IChartPanesRepository ChartPanes { get; }
        IChartAnimationsRepository ChartAnimations { get; }
        ITimestepsRepository Timesteps { get; }
        IPhasesSequencesRepository PhasesSequences { get; }
        IProcessesListRepository ProcessesList { get; }
        IOperatorsCalendarRepository OperatorsCalendar { get; }
        IOperatorsRepository Operators { get; }
        IMacroProcessesRepository MacroProcesses { get; }
        IDeclarationValuesRepository DeclarationValues { get; }
        IDeclarationsRepository Declarations { get; }
        ICustomersRepository Customers { get; }
        IChartConstantLineRepository ChartConstantLine { get; }
        IChartAxisTitleRepository ChartAxisTitle { get; }
        IChartTitleRepository ChartTitle { get; }
        IDepartmentAccessRepository DepartmentAccess { get; }
        IItemsRepository Items { get; }
        IChartCrosshairRepository ChartCrosshair { get; }
        IGridTooltipRepository ToolTipGrid { get; }
        ISchedulerFlyoutAppointmentRepository SchedulerFlyoutAppointment { get; }
        IPhasesConstraintsRepository PhasesConstraints { get; }
        IConstraintConditionsRepository ConstraintConditions { get; }
        IPhasesListRepository PhasesList { get; }
        IAssignmentsRepository Assignments { get; }
        IKanBanGroupRepository KanBanGroup { get; }
        IKanBanItemRepository KanBanItem { get; }
        IKanBanBoardRepository KanBanBoard { get; }
        IInputWizardRepository InputWizard { get; }
        IInputStepWizardRepository InputStepWizard { get; }
        IInputControlRepository InputControl { get; }
        IEventRepository Event { get; }
        IEventLogRepository EventLog { get; }
        IPresenceDeclarationsRepository PresenceDeclarations { get; }
        ICompanyCalendarRepository CompanyCalendar { get; }
        IKpiParametersRepository KpiParameters { get; }
        IKpiRepository Kpi { get; }
        IItemValueRepository ItemValue { get; }
        IBomRepository Bom { get; }
        IOrdersRepository Orders { get; }
        IOrderValueRepository OrderValue { get; }
        IOrderRowRepository OrderRow { get; }
        IDeclarationsFutureRepository DeclarationsFuture { get; }
        IKcfPlannerRepository Kcf { get; }
        IProposalOrderRepository Proposal { get; }
        IWarehouseItemRepository WarehouseItem { get; }
        IBomPhasesRepository BomPhases { get; }
        IWarehouseMovementRepository WarehouseMovement { get; }
        ITrackRepository Track { get; }
        IPhasesCompanyRepository PhasesCompany { get; }
        IDocumentArchiveRepository DocumentArchive { get; }
        IDocumentArchiveValueRepository DocumentArchiveValue { get; }
        IItemGraphicComponentRepository ItemGraphicComponent { get; }
        ICompanyThemeRepository CompanyTheme { get; }
        IGeneralSettingActiveRepository GeneralSettingActive { get; }
        IItemParameterCompanyRepository ItemParameterCompany { get; }
        void Save();
    }
}
