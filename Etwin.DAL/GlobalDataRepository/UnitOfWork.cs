using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Threading;

namespace Etwin.DAL.GlobalDataRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GlobalDbContext _db;

        public IAnalysisDrawingsRepository AnalysisDrawings { get; private set; }
        public IBomTypeRepository BomType { get; private set; }
        public IConstraintTypesRepository ConstraintTypes { get; private set; }
        public ICurrencyRepository Currency { get; private set; }
        public IDeclarationParametersRepository DeclarationParameters { get; private set; }
        public IDepartmentsRepository Departments { get; private set; }
        public IDocumentArchiveParametersRepository DocumentArchiveParameters { get; private set; }
        public IDocumentTypeRepository DocumentType { get; private set; }
        public IDrawingStatesRepository DrawingStates { get; private set; }
        public IExchangerTypesRepository ExchangerTypes { get; private set; }
        public IGeneralSettingsRepository GeneralSettings { get; private set; }
        public IInputControlTypeRepository InputControlType { get; private set; }
        public IItemParametersRepository ItemParameters { get; private set; }
        public IItemShapesRepository ItemShapes { get; private set; }
        public IItemTypeRepository ItemType { get; private set; }
        public IItemWorkingRepository ItemWorking { get; private set; }
        public IMachineDeclarationParametersRepository MachineDeclarationParameters { get; private set; }
        public IMachineStatesRepository MachineStates { get; private set; }
        public IMaterialCategoriesRepository MaterialCategories { get; private set; }
        public IMaterialCodeRepository MaterialCode { get; private set; }
        public IMaterialCodeValueRepository MaterialCodeValue{ get; private set; }
        public IMaterialStandardRepository MaterialStandard { get; private set; }
        public IMaterialSubCategoriesRepository MaterialSubCategories { get; private set; }
        public IMaterialSubCategoriesValueRepository MaterialSubCategoriesValue { get; private set; }
        public IMaterialTypeRepository MaterialType { get; private set; }
        public IMeasureUnitRepository MeasureUnit { get; private set; }
        public IMeasureUnitGroupRepository MeasureUnitGroup { get; private set; }
        public IMovementTypesRepository MovementTypes { get; private set; }
        public IOperatorAccessRepository OperatorAccess { get; private set; }
        public IOperatorActiveStatesRepository OperatorActiveStates { get; private set; }
        public IOperatorParametersRepository OperatorParameters { get; private set; }
        public IOperatorRolesRepository OperatorRoles { get; private set; }
        public IOperatorStatesRepository OperatorStates { get; private set; }
        public IOrderParametersRepository OrderParameters { get; private set; }
        public IOrderStatesRepository OrderStates { get; private set; }
        public IOrderTypeRepository OrderType { get; private set; }
        public IPedRepository Ped {  get; private set; }
        public IPhaseActivitiesRepository PhaseActivities { get; private set; }
        public IPhaseMethodsRepository PhaseMethods { get; private set; }
        public IPhasesRepository Phases { get; private set; }
        public IPhasesItemParametersRepository PhasesItemParameters {  get; private set; }
        public IPhasesListStatesRepository PhasesListStates { get; private set; }
        public IPhasesTypeRepository PhasesType { get; private set; }
        public IPresenceStatesRepository PresenceStates { get; private set; }
        public IProcessingMethodsRepository ProcessingMethods { get; private set; }
        public IProgramVersionRepository ProgramVersion { get; private set; }
        public IProposalStateRepository ProposalState { get; private set; }
        public IPhaseStatesRepository PhaseStates { get; private set; }
        public IProposalTypeRepository ProposalType { get; private set; }
        public IPurchaseOrderParametersRepository PurchaseOrderParameters { get; private set; }
        public ITaxCodeRepository TaxCode { get; private set; }
        public ITraceabilityRepository Traceability { get; private set; }
        public ITraceabilityParameterRepository TraceabilityParameter { get; private set; }
        public IValueTypesRepository ValueTypes { get; private set; }
        public IWarehouseMovementTypesRepository WarehouseMovementTypes { get; private set; }
        public IWarehouseProvenancesRepository WarehouseProvenances { get; private set; }
        public IWarehousesRepository Warehouses { get; private set; }
        public IWarehouseTypesRepository WarehouseTypes { get; private set; }
        public IWebTagsRepository WebTags { get; private set; }
        public IWorkingModesRepository WorkingModes { get; private set; }
        public IChartSeriesTypeRepository ChartSeriesType { get; private set; }
        public IControlTypeRepository ControlType { get; private set; }
        public IEventStateRepository EventState { get; private set; }
        public IGridsColumnsTypeRepository GridsColumnsType { get; private set; }
        public ISchedulersTypeRepository SchedulersType { get; private set; }
        public UnitOfWork(GlobalDbContext db)
        {
            this._db = db;
            this.AnalysisDrawings = new AnalysisDrawingsRepository(this._db);
            this.BomType = new BomTypeRepository(this._db);
            this.ConstraintTypes = new ConstraintTypesRepository(this._db);
            this.Currency = new CurrencyRepository(this._db);
            this.DeclarationParameters = new DeclarationParametersRepository(this._db);
            this.Departments = new DepartmentsRepository(this._db);
            this.DocumentArchiveParameters = new DocumentArchiveParametersRepository(this._db);
            this.DocumentType = new DocumentTypeRepository(this._db);
            this.DrawingStates = new DrawingStatesRepository(this._db);
            this.ExchangerTypes = new ExchangerTypesRepository(this._db);
            this.GeneralSettings = new GeneralSettingsRepository(this._db);
            this.InputControlType = new InputControlTypeRepository(this._db);
            this.ItemParameters = new ItemParametersRepository(this._db);
            this.ItemShapes = new ItemShapesRepository(this._db);
            this.ItemType = new ItemTypeRepository(this._db);
            this.ItemWorking = new ItemWorkingRepository(this._db);
            this.MachineDeclarationParameters = new MachineDeclarationParametersRepository(this._db);
            this.MachineStates = new MachineStatesRepository(this._db);
            this.MaterialCategories = new MaterialCategoriesRepository(this._db);
            this.MaterialCode = new MaterialCodeRepository(this._db);
            this.MaterialCodeValue = new MaterialCodeValueRepository(this._db);
            this.MaterialStandard = new MaterialStandardRepository(this._db);
            this.MaterialSubCategories = new MaterialSubCategoriesRepository(this._db);
            this.MaterialType = new MaterialTypeRepository(this._db);
            this.MeasureUnit = new MeasureUnitRepository(this._db);
            this.MeasureUnitGroup = new MeasureUnitGroupRepository(this._db);
            this.MovementTypes = new MovementTypesRepository(this._db);
            this.OperatorAccess = new OperatorAccessRepository(this._db);
            this.OperatorActiveStates = new OperatorActiveStatesRepository(this._db);
            this.OperatorParameters = new OperatorParametersRepository(this._db);
            this.OperatorRoles = new OperatorRolesRepository(this._db);
            this.MaterialSubCategoriesValue = new MaterialSubCategoriesValueRepository(this._db);
            this.OperatorStates = new OperatorStatesRepository(this._db);
            this.OrderParameters = new OrderParametersRepository(this._db);
            this.OrderStates = new OrderStatesRepository(this._db);
            this.OrderType = new OrderTypeRepository(this._db);
            this.Ped = new PedRepository(this._db);
            this.PhaseActivities = new PhaseActivitiesRepository(this._db);
            this.PhaseMethods = new PhaseMethodsRepository(this._db);
            this.Phases = new PhasesRepository(this._db);
            this.PhasesItemParameters = new PhasesItemParametersRepository(this._db);
            this.PhasesListStates = new PhasesListStatesRepository(this._db);
            this.PhaseStates = new PhaseStatesRepository(this._db);
            this.PhasesType = new PhasesTypeRepository(this._db);
            this.PresenceStates = new PresenceStatesRepository(this._db);
            this.ProcessingMethods = new ProcessingMethodsRepository(this._db);
            this.ProgramVersion = new ProgramVersionRepository(this._db);
            this.ProposalType = new ProposalTypeRepository(this._db);
            this.ProposalState = new ProposalStateRepository(this._db);
            this.PurchaseOrderParameters = new PurchaseOrderParametersRepository(this._db);
            this.TaxCode = new TaxCodeRepository(this._db);
            this.Traceability = new TraceabilityRepository(this._db);
            this.TraceabilityParameter = new TraceabilityParameterRepository(this._db);
            this.ValueTypes = new ValueTypesRepository(this._db);
            this.WarehouseMovementTypes = new WarehouseMovementTypesRepository(this._db);
            this.WarehouseProvenances = new WarehouseProvenancesRepository(this._db);
            this.Warehouses = new WarehousesRepository(this._db);
            this.WarehouseTypes = new WarehouseTypesRepository(this._db);
            this.WebTags = new WebTagsRepository(this._db);
            this.WorkingModes = new WorkingModesRepository(this._db);
            this.ChartSeriesType = new ChartSeriesTypeRepository(this._db);
            this.ControlType = new ControlTypeRepository(this._db);
            this.EventState = new EventStateRepository(this._db);
            this.GridsColumnsType = new GridsColumnsTypeRepository(this._db);
            this.SchedulersType = new SchedulersTypeRepository(this._db);
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
