using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Etwin.Model.GlobalModels;
using ValueType = Etwin.Model.GlobalModels.ValueType;

#nullable disable

namespace Etwin.Model.Context
{
    public partial class GlobalDbContext : DbContext
    {
        public GlobalDbContext()
        {
        }

        public GlobalDbContext(DbContextOptions<GlobalDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnalysisDrawing> AnalysisDrawings { get; set; }
        public virtual DbSet<BomType> BomTypes { get; set; }
        public virtual DbSet<ChartSeriesType> ChartSeriesTypes { get; set; }
        public virtual DbSet<ConstraintType> ConstraintTypes { get; set; }
        public virtual DbSet<ControlType> ControlTypes { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<DeclarationParameter> DeclarationParameters { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DocumentArchiveParameter> DocumentArchiveParameters { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<DrawingState> DrawingStates { get; set; }
        public virtual DbSet<EventState> EventStates { get; set; }
        public virtual DbSet<ExchangerType> ExchangerTypes { get; set; }
        public virtual DbSet<GeneralSetting> GeneralSettings { get; set; }
        public virtual DbSet<GridsColumnsType> GridsColumnsTypes { get; set; }
        public virtual DbSet<InputControlType> InputControlTypes { get; set; }
        public virtual DbSet<ItemParameter> ItemParameters { get; set; }
        public virtual DbSet<ItemShape> ItemShapes { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<ItemWorking> ItemWorkings { get; set; }
        public virtual DbSet<MachineDeclarationParameter> MachineDeclarationParameters { get; set; }
        public virtual DbSet<MachineState> MachineStates { get; set; }
        public virtual DbSet<MaterialCategory> MaterialCategories { get; set; }
        public virtual DbSet<MaterialCode> MaterialCodes { get; set; }
        public virtual DbSet<MaterialCodeValue> MaterialCodeValues { get; set; }
        public virtual DbSet<MaterialStandard> MaterialStandards { get; set; }
        public virtual DbSet<MaterialSubCategoriesValue> MaterialSubCategoriesValues { get; set; }
        public virtual DbSet<MaterialSubCategory> MaterialSubCategories { get; set; }
        public virtual DbSet<MaterialType> MaterialTypes { get; set; }
        public virtual DbSet<MeasureUnit> MeasureUnits { get; set; }
        public virtual DbSet<MeasureUnitGroup> MeasureUnitGroups { get; set; }
        public virtual DbSet<MovementType> MovementTypes { get; set; }
        public virtual DbSet<OperatorAccess> OperatorAccesses { get; set; }
        public virtual DbSet<OperatorActiveState> OperatorActiveStates { get; set; }
        public virtual DbSet<OperatorParameter> OperatorParameters { get; set; }
        public virtual DbSet<OperatorRole> OperatorRoles { get; set; }
        public virtual DbSet<OperatorState> OperatorStates { get; set; }
        public virtual DbSet<OrderParameter> OrderParameters { get; set; }
        public virtual DbSet<OrderState> OrderStates { get; set; }
        public virtual DbSet<OrderType> OrderTypes { get; set; }
        public virtual DbSet<Ped> Peds { get; set; }
        public virtual DbSet<Phase> Phases { get; set; }
        public virtual DbSet<PhaseActivity> PhaseActivities { get; set; }
        public virtual DbSet<PhaseMethod> PhaseMethods { get; set; }
        public virtual DbSet<PhaseState> PhaseStates { get; set; }
        public virtual DbSet<PhasesItemParameter> PhasesItemParameters { get; set; }
        public virtual DbSet<PhasesListState> PhasesListStates { get; set; }
        public virtual DbSet<PhasesType> PhasesTypes { get; set; }
        public virtual DbSet<PresenceState> PresenceStates { get; set; }
        public virtual DbSet<ProcessingMethod> ProcessingMethods { get; set; }
        public virtual DbSet<ProgramVersion> ProgramVersions { get; set; }
        public virtual DbSet<ProposalState> ProposalStates { get; set; }
        public virtual DbSet<ProposalType> ProposalTypes { get; set; }
        public virtual DbSet<PurchaseOrderParameter> PurchaseOrderParameters { get; set; }
        public virtual DbSet<SchedulersType> SchedulersTypes { get; set; }
        public virtual DbSet<TaxCode> TaxCodes { get; set; }
        public virtual DbSet<Traceability> Traceabilities { get; set; }
        public virtual DbSet<TraceabilityParameter> TraceabilityParameters { get; set; }
        public virtual DbSet<ValueType> ValueTypes { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<WarehouseMovementType> WarehouseMovementTypes { get; set; }
        public virtual DbSet<WarehouseProvenance> WarehouseProvenances { get; set; }
        public virtual DbSet<WarehouseType> WarehouseTypes { get; set; }
        public virtual DbSet<WebTag> WebTags { get; set; }
        public virtual DbSet<WorkingMode> WorkingModes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=host8728.shserver.it,1438;Initial Catalog=GlobalDb;Persist Security Info=True;User ID=sa;Password=NmlILt68qnWCQT7Eog;TrustServerCertificate=True;MultipleActiveResultSets=True;App=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AnalysisDrawing>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdDrawingStateNavigation)
                    .WithMany(p => p.AnalysisDrawings)
                    .HasForeignKey(d => d.IdDrawingState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnalyzesDrawings_DrawingStates");
            });

            modelBuilder.Entity<ChartSeriesType>(entity =>
            {
                entity.Property(e => e.SeriesType).IsUnicode(false);
            });

            modelBuilder.Entity<ControlType>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("PK_DashboardItemType");

                entity.Property(e => e.ControlName).IsUnicode(false);

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<DeclarationParameter>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdValueTypeNavigation)
                    .WithMany(p => p.DeclarationParameters)
                    .HasForeignKey(d => d.IdValueType)
                    .HasConstraintName("FK_DeclarationParameters_ValueType");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Name).UseCollation("Latin1_General_CI_AS");
            });

            modelBuilder.Entity<DocumentArchiveParameter>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdValueTypeNavigation)
                    .WithMany(p => p.DocumentArchiveParameters)
                    .HasForeignKey(d => d.IdValueType)
                    .HasConstraintName("FK_DocumentArchiveParameters_ValueType");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<DrawingState>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ExchangerType>(entity =>
            {
                entity.HasKey(e => e.IdExchangerTypes)
                    .HasName("PK_ETwinTipoScambiatore");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<GeneralSetting>(entity =>
            {
                entity.HasOne(d => d.IdDepartmentNavigation)
                    .WithMany(p => p.GeneralSettings)
                    .HasForeignKey(d => d.IdDepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GeneralSettings_Departments");
            });

            modelBuilder.Entity<GridsColumnsType>(entity =>
            {
                entity.Property(e => e.DataCreazione).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Descrizione).IsUnicode(false);

                entity.Property(e => e.Valore).IsUnicode(false);
            });

            modelBuilder.Entity<ItemParameter>(entity =>
            {
                entity.Property(e => e.Calculation).UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExecutionOrder)
                    .IsFixedLength(true)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.FilterCommand).UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.ItemParameterName).UseCollation("Latin1_General_CI_AS");

                entity.HasOne(d => d.IdItemTypeNavigation)
                    .WithMany(p => p.ItemParameters)
                    .HasForeignKey(d => d.IdItemType)
                    .HasConstraintName("FK_ItemParameters_ItemType");

                entity.HasOne(d => d.IdValueTypeNavigation)
                    .WithMany(p => p.ItemParameters)
                    .HasForeignKey(d => d.IdValueType)
                    .HasConstraintName("FK_ItemParameters_ValueType");
            });

            modelBuilder.Entity<ItemShape>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdItemTypeNavigation)
                    .WithMany(p => p.ItemShapes)
                    .HasForeignKey(d => d.IdItemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemShapes_ItemType");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdTypeParentNavigation)
                    .WithMany(p => p.InverseIdTypeParentNavigation)
                    .HasForeignKey(d => d.IdTypeParent)
                    .HasConstraintName("FK_ItemType_ItemType");
            });

            modelBuilder.Entity<ItemWorking>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdItemTypeNavigation)
                    .WithMany(p => p.ItemWorkings)
                    .HasForeignKey(d => d.IdItemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemWorking_ItemType");
            });

            modelBuilder.Entity<MachineDeclarationParameter>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdValueTypeNavigation)
                    .WithMany(p => p.MachineDeclarationParameters)
                    .HasForeignKey(d => d.IdValueType)
                    .HasConstraintName("FK_MachineDeclarationParameters_ValueType");
            });

            modelBuilder.Entity<MaterialCategory>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MaterialCode>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdSubCategoryNavigation)
                    .WithMany(p => p.MaterialCodes)
                    .HasForeignKey(d => d.IdSubCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialCode_MaterialSubCategories");
            });

            modelBuilder.Entity<MaterialCodeValue>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdMaterialCodeNavigation)
                    .WithMany(p => p.MaterialCodeValues)
                    .HasForeignKey(d => d.IdMaterialCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialCodeValue_MaterialCode");
            });

            modelBuilder.Entity<MaterialStandard>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdMaterialCodeNavigation)
                    .WithMany(p => p.MaterialStandards)
                    .HasForeignKey(d => d.IdMaterialCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialStandard_MaterialCode");
            });

            modelBuilder.Entity<MaterialSubCategoriesValue>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdMaterialSubCategoriesNavigation)
                    .WithMany(p => p.MaterialSubCategoriesValues)
                    .HasForeignKey(d => d.IdMaterialSubCategories)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialSubCategoriesValues_MaterialSubCategories");
            });

            modelBuilder.Entity<MaterialSubCategory>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdMaterialCategoriesNavigation)
                    .WithMany(p => p.MaterialSubCategories)
                    .HasForeignKey(d => d.IdMaterialCategories)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialSubCategories_MaterialCategories");
            });

            modelBuilder.Entity<MaterialType>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<OperatorAccess>(entity =>
            {
                entity.Property(e => e.AccessType).IsUnicode(false);
            });

            modelBuilder.Entity<OperatorParameter>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdValueTypeNavigation)
                    .WithMany(p => p.OperatorParameters)
                    .HasForeignKey(d => d.IdValueType)
                    .HasConstraintName("FK_OperatorParameters_ValueType");
            });

            modelBuilder.Entity<OperatorRole>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<OperatorState>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<OrderParameter>(entity =>
            {
                entity.HasKey(e => e.IdOrderParameter)
                    .HasName("PK_OrderParameter");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdValueTypeNavigation)
                    .WithMany(p => p.OrderParameters)
                    .HasForeignKey(d => d.IdValueType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderParameters_ValueType");
            });

            modelBuilder.Entity<OrderState>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<OrderType>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Ped>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Phase>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Phase1).UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.PhaseCode).UseCollation("Latin1_General_CI_AS");

                entity.HasOne(d => d.IdDepartmentNavigation)
                    .WithMany(p => p.Phases)
                    .HasForeignKey(d => d.IdDepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Phases_Departments");

                entity.HasOne(d => d.IdPhaseTypeNavigation)
                    .WithMany(p => p.Phases)
                    .HasForeignKey(d => d.IdPhaseType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Phases_PhasesType");
            });

            modelBuilder.Entity<PhaseActivity>(entity =>
            {
                entity.HasKey(e => e.IdPhaseActivity)
                    .HasName("PK_TaskActivity");
            });

            modelBuilder.Entity<PhaseMethod>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PhaseState>(entity =>
            {
                entity.HasKey(e => e.IdPhaseStates)
                    .HasName("PK_TaskStates");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PhasesItemParameter>(entity =>
            {
                entity.HasOne(d => d.IdItemParameterNavigation)
                    .WithMany(p => p.PhasesItemParameters)
                    .HasForeignKey(d => d.IdItemParameter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhasesItemParameters_ItemParameters");

                entity.HasOne(d => d.IdPhaseNavigation)
                    .WithMany(p => p.PhasesItemParameters)
                    .HasForeignKey(d => d.IdPhase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhasesItemParameters_PhasesItemParameters");
            });

            modelBuilder.Entity<PhasesListState>(entity =>
            {
                entity.HasKey(e => e.IdPhaseListState)
                    .HasName("PK_PhaseListStates");
            });

            modelBuilder.Entity<ProgramVersion>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PurchaseOrderParameter>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdValueTypeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdValueType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseOrderParameters_ValueType");
            });

            modelBuilder.Entity<SchedulersType>(entity =>
            {
                entity.Property(e => e.SchedulerType).IsUnicode(false);
            });

            modelBuilder.Entity<TraceabilityParameter>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdValueTypeNavigation)
                    .WithMany(p => p.TraceabilityParameters)
                    .HasForeignKey(d => d.IdValueType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraceabilityParameter_ValueType");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasOne(d => d.IdDepartmentNavigation)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.IdDepartment)
                    .HasConstraintName("FK_WareHouses_Departments");

                entity.HasOne(d => d.IdWareHouseTypeNavigation)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.IdWareHouseType)
                    .HasConstraintName("FK_WareHouses_WarehouseType");
            });

            modelBuilder.Entity<WarehouseMovementType>(entity =>
            {
                entity.HasOne(d => d.IdMovementTypeNavigation)
                    .WithMany(p => p.WarehouseMovementTypes)
                    .HasForeignKey(d => d.IdMovementType)
                    .HasConstraintName("FK_WarehouseMovementTypes_MovementTypes");
            });

            modelBuilder.Entity<WebTag>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WebTag1).UseCollation("Latin1_General_CI_AS");

                entity.HasOne(d => d.IdPhaseNavigation)
                    .WithMany(p => p.WebTags)
                    .HasForeignKey(d => d.IdPhase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WebTags_Phases");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
