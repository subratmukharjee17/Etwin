using Etwin.DAL.DataRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.GlobalDataRepository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IAnalysisDrawingsRepository AnalysisDrawings { get; }
        IBomTypeRepository BomType { get; }
        IConstraintTypesRepository ConstraintTypes { get; }
        ICurrencyRepository Currency { get; }
        IDeclarationParametersRepository DeclarationParameters { get; }
        IDepartmentsRepository Departments { get; }
        IDocumentArchiveParametersRepository DocumentArchiveParameters { get; }
        IDocumentTypeRepository DocumentType { get; }
        IDrawingStatesRepository DrawingStates { get; }
        IExchangerTypesRepository ExchangerTypes { get; }
        IGeneralSettingsRepository GeneralSettings { get; }
        IInputControlTypeRepository InputControlType { get; }
        IItemParametersRepository ItemParameters { get; }
        IItemShapesRepository ItemShapes { get; }
        IItemTypeRepository ItemType { get; }
        IItemWorkingRepository ItemWorking { get; }
        IMachineDeclarationParametersRepository MachineDeclarationParameters { get; }
        IMachineStatesRepository MachineStates { get; }
        IMaterialCategoriesRepository MaterialCategories { get; }
        IMaterialCodeRepository MaterialCode { get; }
        IMaterialCodeValueRepository MaterialCodeValue { get; }
        IMaterialStandardRepository MaterialStandard { get; }
        IMaterialSubCategoriesRepository MaterialSubCategories { get; }
        IMaterialSubCategoriesValueRepository MaterialSubCategoriesValue { get; }
        IMaterialTypeRepository MaterialType { get; }
        IMeasureUnitRepository MeasureUnit { get; }
        IMeasureUnitGroupRepository MeasureUnitGroup { get; }
        IMovementTypesRepository MovementTypes { get; }
        IOperatorAccessRepository OperatorAccess { get; }
        IOperatorActiveStatesRepository OperatorActiveStates { get; }
        IOperatorParametersRepository OperatorParameters { get; }
        IOperatorRolesRepository OperatorRoles { get; }
        IOperatorStatesRepository OperatorStates { get; }
        IOrderParametersRepository OrderParameters { get; }
        IOrderStatesRepository OrderStates { get; }
        IOrderTypeRepository OrderType { get; }
        IPedRepository Ped {  get; }
        IPhaseActivitiesRepository PhaseActivities { get; }
        IPhaseMethodsRepository PhaseMethods { get; }
        IPhasesRepository Phases { get; }
        IPhasesItemParametersRepository PhasesItemParameters { get; }
        IPhasesListStatesRepository PhasesListStates { get; }
        IPhasesTypeRepository PhasesType { get; }
        IPresenceStatesRepository PresenceStates { get; }
        IProcessingMethodsRepository ProcessingMethods { get; }
        IProgramVersionRepository ProgramVersion { get; }
        IProposalStateRepository ProposalState { get; }
        IProposalTypeRepository ProposalType { get; }
        IPurchaseOrderParametersRepository PurchaseOrderParameters { get; }
        ITaxCodeRepository TaxCode { get; }
        ITraceabilityRepository Traceability { get; }
        ITraceabilityParameterRepository TraceabilityParameter { get; }
        IValueTypesRepository ValueTypes { get; }
        IWarehouseMovementTypesRepository WarehouseMovementTypes { get; }
        IWarehouseProvenancesRepository WarehouseProvenances { get; }
        IWarehousesRepository Warehouses { get; }
        IWarehouseTypesRepository WarehouseTypes { get; }
        IWebTagsRepository WebTags { get; }
        IWorkingModesRepository WorkingModes { get; }
        IChartSeriesTypeRepository ChartSeriesType { get; }
        IControlTypeRepository ControlType { get; }
        IEventStateRepository EventState { get; }
        IGridsColumnsTypeRepository GridsColumnsType { get; }
        ISchedulersTypeRepository SchedulersType { get; }

        void Save();
    }
}
