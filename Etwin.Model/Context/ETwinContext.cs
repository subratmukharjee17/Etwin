using System;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Newtonsoft.Json;
using ETwin.DAL.Models;
using Newtonsoft.Json.Linq;

#nullable disable

namespace Etwin.Model.Context
{
    public partial class ETwinContext : DbContext
    {
        string cs = String.Empty;
        private readonly string _connectionString;
        public ETwinContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ETwinContext(DbContextOptions<ETwinContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Bom> Boms { get; set; }
        public virtual DbSet<BomPhase> BomPhases { get; set; }
        public virtual DbSet<ChangeLayout> ChangeLayouts { get; set; }
        public virtual DbSet<Chart> Charts { get; set; }
        public virtual DbSet<ChartAnimation> ChartAnimations { get; set; }
        public virtual DbSet<ChartAxisTitle> ChartAxisTitles { get; set; }
        public virtual DbSet<ChartConstantLine> ChartConstantLines { get; set; }
        public virtual DbSet<ChartCrosshair> ChartCrosshairs { get; set; }
        public virtual DbSet<ChartPane> ChartPanes { get; set; }
        public virtual DbSet<ChartSeries> ChartSeries { get; set; }
        public virtual DbSet<ChartStrip> ChartStrips { get; set; }
        public virtual DbSet<ChartTitle> ChartTitles { get; set; }
        public virtual DbSet<CompanyCalendar> CompanyCalendars { get; set; }
        public virtual DbSet<CompanyTheme> CompanyThemes { get; set; }
        public virtual DbSet<ConstraintCondition> ConstraintConditions { get; set; }
        public virtual DbSet<ConstraintsView> ConstraintsViews { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Declaration> Declarations { get; set; }
        public virtual DbSet<DeclarationValue> DeclarationValues { get; set; }
        public virtual DbSet<DeclarationsFuture> DeclarationsFutures { get; set; }
        public virtual DbSet<DeclarationsFutureValue> DeclarationsFutureValues { get; set; }
        public virtual DbSet<DepartmentAccess> DepartmentAccesses { get; set; }
        public virtual DbSet<DocumentArchive> DocumentArchives { get; set; }
        public virtual DbSet<DocumentArchiveValue> DocumentArchiveValues { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventLog> EventLogs { get; set; }
        public virtual DbSet<Gantt> Gantts { get; set; }
        public virtual DbSet<GeneralSettingActive> GeneralSettingActives { get; set; }
        public virtual DbSet<Grid> Grids { get; set; }
        public virtual DbSet<GridBand> GridBands { get; set; }
        public virtual DbSet<GridTooltip> GridTooltips { get; set; }
        public virtual DbSet<GridsColumn> GridsColumns { get; set; }
        public virtual DbSet<InputCompilation> InputCompilations { get; set; }
        public virtual DbSet<InputControl> InputControls { get; set; }
        public virtual DbSet<InputStepWizard> InputStepWizards { get; set; }
        public virtual DbSet<InputWizard> InputWizards { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemCoding> ItemCodings { get; set; }
        public virtual DbSet<ItemGraphicComponent> ItemGraphicComponents { get; set; }
        public virtual DbSet<ItemGraphicCondition> ItemGraphicConditions { get; set; }
        public virtual DbSet<ItemParametersCompany> ItemParametersCompanies { get; set; }
        public virtual DbSet<ItemValue> ItemValues { get; set; }
        public virtual DbSet<KanBanBoard> KanBanBoards { get; set; }
        public virtual DbSet<KanBanGroup> KanBanGroups { get; set; }
        public virtual DbSet<KanBanItem> KanBanItems { get; set; }
        public virtual DbSet<KcfPlanner> KcfPlanners { get; set; }
        public virtual DbSet<Kpi> Kpis { get; set; }
        public virtual DbSet<KpiParameter> KpiParameters { get; set; }
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<MachineDeclaration> MachineDeclarations { get; set; }
        public virtual DbSet<MachineDeclarationValue> MachineDeclarationValues { get; set; }
        public virtual DbSet<MachineGroup> MachineGroups { get; set; }
        public virtual DbSet<MacroProcess> MacroProcesses { get; set; }
        public virtual DbSet<Operator> Operators { get; set; }
        public virtual DbSet<OperatorValue> OperatorValues { get; set; }
        public virtual DbSet<OperatorsCalendar> OperatorsCalendars { get; set; }
        public virtual DbSet<OperatorsEngine> OperatorsEngines { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderRow> OrderRows { get; set; }
        public virtual DbSet<OrderValue> OrderValues { get; set; }
        public virtual DbSet<OrdersTechnicalField> OrdersTechnicalFields { get; set; }
        public virtual DbSet<PhasesCompany> PhasesCompanies { get; set; }
        public virtual DbSet<PhasesConstraint> PhasesConstraints { get; set; }
        public virtual DbSet<PhasesEnginePlanner> PhasesEnginePlanners { get; set; }
        public virtual DbSet<PhasesList> PhasesLists { get; set; }
        public virtual DbSet<PhasesMachine> PhasesMachines { get; set; }
        public virtual DbSet<PhasesSequence> PhasesSequences { get; set; }
        public virtual DbSet<PlannerOutput> PlannerOutputs { get; set; }
        public virtual DbSet<PresenceDeclaration> PresenceDeclarations { get; set; }
        public virtual DbSet<ProcessesList> ProcessesLists { get; set; }
        public virtual DbSet<ProposalOrder> ProposalOrders { get; set; }
        public virtual DbSet<PurchaseList> PurchaseLists { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderRow> PurchaseOrderRows { get; set; }
        public virtual DbSet<PurchaseOrderValue> PurchaseOrderValues { get; set; }
        public virtual DbSet<Range> Ranges { get; set; }
        public virtual DbSet<RangeAreaChart> RangeAreaCharts { get; set; }
        public virtual DbSet<RangeClient> RangeClients { get; set; }
        public virtual DbSet<RibbonsPage> RibbonsPages { get; set; }
        public virtual DbSet<RibbonsPageGroup> RibbonsPageGroups { get; set; }
        public virtual DbSet<RibbonsPageGroupButton> RibbonsPageGroupButtons { get; set; }
        public virtual DbSet<SalesList> SalesLists { get; set; }
        public virtual DbSet<SalesPrice> SalesPrices { get; set; }
        public virtual DbSet<Scheduler> Schedulers { get; set; }
        public virtual DbSet<SchedulerAppointmentMapping> SchedulerAppointmentMappings { get; set; }
        public virtual DbSet<SchedulerDependencyMapping> SchedulerDependencyMappings { get; set; }
        public virtual DbSet<SchedulerFlyoutAppointment> SchedulerFlyoutAppointments { get; set; }
        public virtual DbSet<SchedulerResourceMapping> SchedulerResourceMappings { get; set; }
        public virtual DbSet<SettingItemWorkingShapeCode> SettingItemWorkingShapeCodes { get; set; }
        public virtual DbSet<SettingType> SettingTypes { get; set; }
        public virtual DbSet<SettingsMaterial> SettingsMaterials { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<TimbratoreSetup> TimbratoreSetups { get; set; }
        public virtual DbSet<Timestep> Timesteps { get; set; }
        public virtual DbSet<TraceabilityValue> TraceabilityValues { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<UnitLetter> UnitLetters { get; set; }
        public virtual DbSet<ViewBom> ViewBoms { get; set; }
        public virtual DbSet<ViewDepartmentOpenProcess> ViewDepartmentOpenProcesses { get; set; }
        public virtual DbSet<ViewDurataCommesse> ViewDurataCommesses { get; set; }
        public virtual DbSet<ViewOperatoriPresenze> ViewOperatoriPresenzes { get; set; }
        public virtual DbSet<ViewPartsRequestForBom> ViewPartsRequestForBoms { get; set; }
        public virtual DbSet<ViewProcessDocument> ViewProcessDocuments { get; set; }
        public virtual DbSet<ViewProcessi> ViewProcessis { get; set; }
        public virtual DbSet<ViewTimeLine> ViewTimeLines { get; set; }
        public virtual DbSet<ViewTimeLine1> ViewTimeLine1s { get; set; }
        public virtual DbSet<ViewTimestepGrid> ViewTimestepGrids { get; set; }
        public virtual DbSet<ViewWareHouseStatus> ViewWareHouseStatuses { get; set; }
        public virtual DbSet<WarehouseDocument> WarehouseDocuments { get; set; }
        public virtual DbSet<WarehouseItem> WarehouseItems { get; set; }
        public virtual DbSet<WarehouseItemLocation> WarehouseItemLocations { get; set; }
        public virtual DbSet<WarehouseMovement> WarehouseMovements { get; set; }
        public virtual DbSet<WarehouseMovementDocument> WarehouseMovementDocuments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (_connectionString == null)
                {
                    string jsonPath = "appsettings.json";
                    string jsonString = File.ReadAllText(jsonPath);
                    // Deserialize the JSON in the ConnectionStrings class
                    JObject jsonObj = JObject.Parse(jsonString);
                    string cs = ((JValue)jsonObj["ConnectionStrings"]["CsCust"]).Value.ToString();
                    optionsBuilder.UseSqlServer(cs);
            }
                else
                {
                    optionsBuilder.UseSqlServer(_connectionString);
        }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.Property(e => e.AssignedDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdPhaseCompanyNavigation)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.IdPhaseCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assignments_PhasesCompany");

                entity.HasOne(d => d.IdProcessListNavigation)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.IdProcessList)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assignments_ProcessesList");

                entity.HasOne(d => d.OperatorCodeAssignedByNavigation)
                    .WithMany(p => p.AssignmentOperatorCodeAssignedByNavigations)
                    .HasForeignKey(d => d.OperatorCodeAssignedBy)
                    .HasConstraintName("FK_Assignments_OperatorsAssignedBy");

                entity.HasOne(d => d.OperatorCodeAssignedToNavigation)
                    .WithMany(p => p.AssignmentOperatorCodeAssignedToNavigations)
                    .HasForeignKey(d => d.OperatorCodeAssignedTo)
                    .HasConstraintName("FK_Assignments_OperatorsAssignedTo");
            });

            modelBuilder.Entity<Bom>(entity =>
            {
                entity.Property(e => e.BomLevel).HasComment("Il livello 0 è il prodotto finale, il livello 1 gli assiemi ( componenti), il livello 2 i sottoassiemi (sottocomponenti)");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.Boms)
                    .HasForeignKey(d => d.IdItem)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Boms_Items");

                entity.HasOne(d => d.IdMainBomNavigation)
                    .WithMany(p => p.InverseIdMainBomNavigation)
                    .HasForeignKey(d => d.IdMainBom)
                    .HasConstraintName("FK_Boms_MainBom");
            });

            modelBuilder.Entity<BomPhase>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.BomPhases)
                    .HasForeignKey(d => d.IdItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BomPhases_Items");

                entity.HasOne(d => d.IdPhaseListNavigation)
                    .WithMany(p => p.BomPhases)
                    .HasForeignKey(d => d.IdPhaseList)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BomPhases_PhasesList");
            });

            modelBuilder.Entity<ChangeLayout>(entity =>
            {
                entity.HasKey(e => e.IdOpenStatusBarForm)
                    .HasName("PK_OpenStatusBarForm");

                entity.HasOne(d => d.IdChartNavigation)
                    .WithMany(p => p.ChangeLayouts)
                    .HasForeignKey(d => d.IdChart)
                    .HasConstraintName("FK_OpenStatusBarForm_Charts");

                entity.HasOne(d => d.IdGanttNavigation)
                    .WithMany(p => p.ChangeLayouts)
                    .HasForeignKey(d => d.IdGantt)
                    .HasConstraintName("FK_OpenStatusBarForm_Gantts");

                entity.HasOne(d => d.IdGr)
                    .WithMany(p => p.ChangeLayouts)
                    .HasForeignKey(d => d.IdGrid)
                    .HasConstraintName("FK_OpenStatusBarForm_Grids");

                entity.HasOne(d => d.IdSchedulerNavigation)
                    .WithMany(p => p.ChangeLayouts)
                    .HasForeignKey(d => d.IdScheduler)
                    .HasConstraintName("FK_OpenStatusBarForm_Schedulers");
            });

            modelBuilder.Entity<Chart>(entity =>
            {
                entity.Property(e => e.ChartName).IsUnicode(false);

                entity.Property(e => e.ColorDataMember).IsUnicode(false);

                entity.Property(e => e.ShowLegend).HasDefaultValueSql("((1))");

                entity.Property(e => e.TagDataMember).IsUnicode(false);

                entity.HasOne(d => d.IdAxisTitleNavigation)
                    .WithMany(p => p.Charts)
                    .HasForeignKey(d => d.IdAxisTitle)
                    .HasConstraintName("FK_Charts_ChartAxisTitles");
            });

            modelBuilder.Entity<ChartAnimation>(entity =>
            {
                entity.HasOne(d => d.IdChartNavigation)
                    .WithMany(p => p.ChartAnimations)
                    .HasForeignKey(d => d.IdChart)
                    .HasConstraintName("FK_ChartAnimations_Charts");
            });

            modelBuilder.Entity<ChartAxisTitle>(entity =>
            {
                entity.HasKey(e => e.IdAxisTitle)
                    .HasName("PK_ChartTitles");

                entity.Property(e => e.Xcolor).IsUnicode(false);

                entity.Property(e => e.Xfont).IsUnicode(false);

                entity.Property(e => e.Xtext).IsUnicode(false);

                entity.Property(e => e.Ycolor).IsUnicode(false);

                entity.Property(e => e.Yfont).IsUnicode(false);

                entity.Property(e => e.Ytext).IsUnicode(false);
            });

            modelBuilder.Entity<ChartConstantLine>(entity =>
            {
                entity.Property(e => e.Axis).IsUnicode(false);

                entity.Property(e => e.ColorLine).IsUnicode(false);

                entity.Property(e => e.ColorText).IsUnicode(false);

                entity.Property(e => e.FontFamily).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Text).IsUnicode(false);

                entity.HasOne(d => d.IdChartSerieNavigation)
                    .WithMany(p => p.ChartConstantLines)
                    .HasForeignKey(d => d.IdChartSerie)
                    .HasConstraintName("FK_ChartConstantLine_ChartSeries");
            });

            modelBuilder.Entity<ChartCrosshair>(entity =>
            {
                entity.Property(e => e.ArgumentLineColor).IsUnicode(false);

                entity.Property(e => e.CrossHairFont).IsUnicode(false);

                entity.Property(e => e.CrossHairForeColor).IsUnicode(false);

                entity.Property(e => e.CrossHairLabelName).IsUnicode(false);

                entity.Property(e => e.HeaderFont).IsUnicode(false);

                entity.Property(e => e.HeaderForeColor).IsUnicode(false);

                entity.Property(e => e.LabelBackColor).IsUnicode(false);

                entity.Property(e => e.ValueLineColor).IsUnicode(false);

                entity.HasOne(d => d.IdChartNavigation)
                    .WithMany(p => p.ChartCrosshairs)
                    .HasForeignKey(d => d.IdChart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToolTipChart_ChartSeries");
            });

            modelBuilder.Entity<ChartPane>(entity =>
            {
                entity.Property(e => e.PaneName).IsUnicode(false);

                entity.Property(e => e.PaneTitle).IsUnicode(false);

                entity.HasOne(d => d.IdChartNavigation)
                    .WithMany(p => p.ChartPanes)
                    .HasForeignKey(d => d.IdChart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChartPanes_Charts");
            });

            modelBuilder.Entity<ChartSeries>(entity =>
            {
                entity.Property(e => e.ArgumentDataMember).IsUnicode(false);

                entity.Property(e => e.ColorSerie).IsUnicode(false);

                entity.Property(e => e.LabelTextPattern).IsUnicode(false);

                entity.Property(e => e.LegendTextPattern).IsUnicode(false);

                entity.Property(e => e.SeriesDataMember).IsUnicode(false);

                entity.Property(e => e.ShowLabels).HasDefaultValueSql("((1))");

                entity.Property(e => e.TextPattern).IsUnicode(false);

                entity.Property(e => e.ValueDataMember).IsUnicode(false);

                entity.HasOne(d => d.IdChartNavigation)
                    .WithMany(p => p.ChartSeries)
                    .HasForeignKey(d => d.IdChart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChartSeries_Charts");
            });

            modelBuilder.Entity<ChartStrip>(entity =>
            {
                entity.HasOne(d => d.IdChartSerieNavigation)
                    .WithMany(p => p.ChartStrips)
                    .HasForeignKey(d => d.IdChartSerie)
                    .HasConstraintName("FK_ChartStrips_ChartSeries");
            });

            modelBuilder.Entity<ChartTitle>(entity =>
            {
                entity.Property(e => e.Font).IsUnicode(false);

                entity.Property(e => e.TextColor).IsUnicode(false);

                entity.Property(e => e.TextTitle).IsUnicode(false);

                entity.HasOne(d => d.IdChartNavigation)
                    .WithMany(p => p.ChartTitles)
                    .HasForeignKey(d => d.IdChart)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChartTitle_Charts");
            });

            modelBuilder.Entity<CompanyCalendar>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.OperatorCodeNavigation)
                    .WithMany(p => p.CompanyCalendars)
                    .HasForeignKey(d => d.OperatorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyCalendar_Operators");
            });

            modelBuilder.Entity<ConstraintCondition>(entity =>
            {
                entity.HasKey(e => e.IdConstraintCondition)
                    .HasName("PK_TaskCondition");

                entity.HasOne(d => d.IdPhaseConstraintNavigation)
                    .WithMany(p => p.ConstraintConditions)
                    .HasForeignKey(d => d.IdPhaseConstraint)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhasesConditions_PhasesConstraints");
            });

            modelBuilder.Entity<ConstraintsView>(entity =>
            {
                entity.ToView("ConstraintsView");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("PK_Customers_1");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Declaration>(entity =>
            {
                entity.Property(e => e.DeclarationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdPhaseCompanyNavigation)
                    .WithMany(p => p.Declarations)
                    .HasForeignKey(d => d.IdPhaseCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Declarations_PhasesCompany");

                entity.HasOne(d => d.IdProcessListNavigation)
                    .WithMany(p => p.Declarations)
                    .HasForeignKey(d => d.IdProcessList)
                    .HasConstraintName("FK_Declarations_ProcessesList");

                entity.HasOne(d => d.OperatorCodeNavigation)
                    .WithMany(p => p.Declarations)
                    .HasForeignKey(d => d.OperatorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Declarations_Operators");
            });

            modelBuilder.Entity<DeclarationValue>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdDeclarationsNavigation)
                    .WithMany(p => p.DeclarationValues)
                    .HasForeignKey(d => d.IdDeclarations)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeclarationValues_Declarations");
            });

            modelBuilder.Entity<DeclarationsFuture>(entity =>
            {
                entity.HasOne(d => d.IdPhaseCompanyNavigation)
                    .WithMany(p => p.DeclarationsFutures)
                    .HasForeignKey(d => d.IdPhaseCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeclarationsFuture_PhasesCompany");

                entity.HasOne(d => d.IdProcessListNavigation)
                    .WithMany(p => p.DeclarationsFutures)
                    .HasForeignKey(d => d.IdProcessList)
                    .HasConstraintName("FK_DeclarationsFuture_ProcessesList");

                entity.HasOne(d => d.OperatorCodeNavigation)
                    .WithMany(p => p.DeclarationsFutures)
                    .HasForeignKey(d => d.OperatorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeclarationsFuture_Operators");
            });

            modelBuilder.Entity<DeclarationsFutureValue>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdFutureDeclarationsNavigation)
                    .WithMany(p => p.DeclarationsFutureValues)
                    .HasForeignKey(d => d.IdFutureDeclarations)
                    .HasConstraintName("FK_DeclarationsFutureValue_DeclarationsFuture");
            });

            modelBuilder.Entity<DepartmentAccess>(entity =>
            {
                entity.HasOne(d => d.OperatorCodeNavigation)
                    .WithMany(p => p.DepartmentAccesses)
                    .HasForeignKey(d => d.OperatorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentAccess_Operators");
            });

            modelBuilder.Entity<DocumentArchive>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<DocumentArchiveValue>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdDocumentArchiveNavigation)
                    .WithMany(p => p.DocumentArchiveValues)
                    .HasForeignKey(d => d.IdDocumentArchive)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentArchiveValues_DocumentArchive");
            });

            modelBuilder.Entity<EventLog>(entity =>
            {
                entity.HasOne(d => d.IdEventNavigation)
                    .WithMany(p => p.EventLogs)
                    .HasForeignKey(d => d.IdEvent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventLog_EventDescription");
            });

            modelBuilder.Entity<Gantt>(entity =>
            {
                entity.Property(e => e.FinishDateFieldName).IsUnicode(false);

                entity.Property(e => e.GanttName).IsUnicode(false);

                entity.Property(e => e.GanttTitle).IsUnicode(false);

                entity.Property(e => e.KeyFieldName).IsUnicode(false);

                entity.Property(e => e.ParentFieldName).IsUnicode(false);

                entity.Property(e => e.PredecessorsFieldName).IsUnicode(false);

                entity.Property(e => e.ProgressFieldName).IsUnicode(false);

                entity.Property(e => e.StartDateFieldName).IsUnicode(false);

                entity.Property(e => e.TextFieldName).IsUnicode(false);
            });

            modelBuilder.Entity<Grid>(entity =>
            {
                entity.Property(e => e.Caption).IsUnicode(false);

                entity.Property(e => e.FontName).IsUnicode(false);

                entity.Property(e => e.GridName).IsUnicode(false);

                entity.Property(e => e.RelationKey).IsUnicode(false);

                entity.Property(e => e.SqlQuery).IsUnicode(false);

                entity.HasOne(d => d.IdgridParentNavigation)
                    .WithMany(p => p.InverseIdgridParentNavigation)
                    .HasForeignKey(d => d.IdgridParent)
                    .HasConstraintName("FK_Grids_Grids");
            });

            modelBuilder.Entity<GridBand>(entity =>
            {
                entity.Property(e => e.BandName).IsUnicode(false);

                entity.Property(e => e.Caption).IsUnicode(false);

                entity.Property(e => e.FontName).IsUnicode(false);

                entity.Property(e => e.ToolTip).IsUnicode(false);

                entity.HasOne(d => d.IdGr)
                    .WithMany(p => p.GridBands)
                    .HasForeignKey(d => d.IdGrid)
                    .HasConstraintName("FK_Bands_Grids");
            });

            modelBuilder.Entity<GridTooltip>(entity =>
            {
                entity.Property(e => e.Font).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Text).IsUnicode(false);

                entity.HasOne(d => d.IdGridColumnNavigation)
                    .WithMany(p => p.GridTooltips)
                    .HasForeignKey(d => d.IdGridColumn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToolTipItemControl_GridsColumns");
            });

            modelBuilder.Entity<GridsColumn>(entity =>
            {
                entity.Property(e => e.AllowGroup).HasDefaultValueSql("((1))");

                entity.Property(e => e.BackColor).IsUnicode(false);

                entity.Property(e => e.ColumnName).IsUnicode(false);

                entity.Property(e => e.ColumnText).IsUnicode(false);

                entity.Property(e => e.ColumnTooltip).IsUnicode(false);

                entity.Property(e => e.FontName).IsUnicode(false);

                entity.Property(e => e.ForeColor).IsUnicode(false);

                entity.HasOne(d => d.IdBandNavigation)
                    .WithMany(p => p.GridsColumns)
                    .HasForeignKey(d => d.IdBand)
                    .HasConstraintName("FK_Columns_Bands");
            });

            modelBuilder.Entity<InputCompilation>(entity =>
            {
                entity.HasOne(d => d.IdInputControlNavigation)
                    .WithMany(p => p.InputCompilationIdInputControlNavigations)
                    .HasForeignKey(d => d.IdInputControl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InputCompilation_InputControl");

                entity.HasOne(d => d.IdInputControlToCompleteNavigation)
                    .WithMany(p => p.InputCompilationIdInputControlToCompleteNavigations)
                    .HasForeignKey(d => d.IdInputControlToComplete)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InputCompilation_InputControlToComplete");
            });

            modelBuilder.Entity<InputControl>(entity =>
            {
                entity.HasOne(d => d.IdCustomStepWizardNavigation)
                    .WithMany(p => p.InputControls)
                    .HasForeignKey(d => d.IdCustomStepWizard)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomControl_CustomWizard");
            });

            modelBuilder.Entity<InputStepWizard>(entity =>
            {
                entity.HasOne(d => d.IdCustomWizardNavigation)
                    .WithMany(p => p.InputStepWizards)
                    .HasForeignKey(d => d.IdCustomWizard)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomStepWizard_CustomWizard");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdSettingTypeNavigation)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.IdSettingType)
                    .HasConstraintName("FK_Items_SettingType");
            });

            modelBuilder.Entity<ItemCoding>(entity =>
            {
                entity.Property(e => e.CreazionDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdSettingTypeNavigation)
                    .WithMany(p => p.ItemCodings)
                    .HasForeignKey(d => d.IdSettingType)
                    .HasConstraintName("FK_ItemCoding_SettingType");
            });

            modelBuilder.Entity<ItemGraphicComponent>(entity =>
            {
                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.ItemGraphicComponents)
                    .HasForeignKey(d => d.IdItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemGraphicComponents_Items");
            });

            modelBuilder.Entity<ItemParametersCompany>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ItemValue>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.ItemValues)
                    .HasForeignKey(d => d.IdItem)
                    .HasConstraintName("FK_ItemValues_Items");

                entity.HasOne(d => d.IdItemParameterCompanyNavigation)
                    .WithMany(p => p.ItemValues)
                    .HasForeignKey(d => d.IdItemParameterCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemValues_ItemParametersCompany");
            });

            modelBuilder.Entity<KanBanBoard>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Query).IsUnicode(false);
            });

            modelBuilder.Entity<KanBanGroup>(entity =>
            {
                entity.Property(e => e.Caption).IsUnicode(false);

                entity.Property(e => e.Font).IsUnicode(false);

                entity.Property(e => e.FooterText).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.HasOne(d => d.IdBoardNavigation)
                    .WithMany(p => p.KanBanGroups)
                    .HasForeignKey(d => d.IdBoard)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KanBanGroup_KanBanBoard");
            });

            modelBuilder.Entity<KanBanItem>(entity =>
            {
                entity.Property(e => e.Caption).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.KanBanItems)
                    .HasForeignKey(d => d.IdGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KanBanItem_KanBanGroup");
            });

            modelBuilder.Entity<KcfPlanner>(entity =>
            {
                entity.HasKey(e => e.IdKcf)
                    .HasName("PK_KCF_1");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.OperatorCodeNavigation)
                    .WithMany(p => p.KcfPlanners)
                    .HasForeignKey(d => d.OperatorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KCF_OperatorsEngine");
            });

            modelBuilder.Entity<KpiParameter>(entity =>
            {
                entity.HasOne(d => d.IdKpiNavigation)
                    .WithMany(p => p.KpiParameters)
                    .HasForeignKey(d => d.IdKpi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KPIParameters_Kpi");
            });

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdMachineGroupNavigation)
                    .WithMany(p => p.Machines)
                    .HasForeignKey(d => d.IdMachineGroup)
                    .HasConstraintName("FK_Machine_MachineGroup");
            });

            modelBuilder.Entity<MachineDeclaration>(entity =>
            {
                entity.Property(e => e.DeclarationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdMachineNavigation)
                    .WithMany(p => p.MachineDeclarations)
                    .HasForeignKey(d => d.IdMachine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MachineDeclarations_Machines");

                entity.HasOne(d => d.IdPhaseCompanyNavigation)
                    .WithMany(p => p.MachineDeclarations)
                    .HasForeignKey(d => d.IdPhaseCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MachineDeclarations_PhasesCompany");

                entity.HasOne(d => d.IdProcessListNavigation)
                    .WithMany(p => p.MachineDeclarations)
                    .HasForeignKey(d => d.IdProcessList)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MachineDeclarations_ProcessesList");
            });

            modelBuilder.Entity<MachineDeclarationValue>(entity =>
            {
                entity.Property(e => e.IdMachineDeclarationValue).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdMachineDeclarationNavigation)
                    .WithMany(p => p.MachineDeclarationValues)
                    .HasForeignKey(d => d.IdMachineDeclaration)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MachineDeclarationValues_MachineDeclarations");
            });

            modelBuilder.Entity<MachineGroup>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MacroProcess>(entity =>
            {
                entity.HasKey(e => e.IdMacroProcess)
                    .HasName("PK_MacroProcesses_1");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<OperatorValue>(entity =>
            {
                entity.Property(e => e.IdOperatorValue).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.OperatorCodeNavigation)
                    .WithMany(p => p.OperatorValues)
                    .HasForeignKey(d => d.OperatorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OperatorValues_Operators");
            });

            modelBuilder.Entity<OperatorsCalendar>(entity =>
            {
                entity.HasOne(d => d.OperatorCodeNavigation)
                    .WithMany(p => p.OperatorsCalendars)
                    .HasForeignKey(d => d.OperatorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OperatorsCalendar_Operators");
            });

            modelBuilder.Entity<OperatorsEngine>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<OrderRow>(entity =>
            {
                entity.HasKey(e => e.IdOrderRow)
                    .HasName("PK_OrdersProva");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.OrderRows)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_OrderRows_Customers");

                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.OrderRows)
                    .HasForeignKey(d => d.IdItem)
                    .HasConstraintName("FK_OrderRows_Items");

                entity.HasOne(d => d.IdOrderParentNavigation)
                    .WithMany(p => p.OrderRows)
                    .HasForeignKey(d => d.IdOrderParent)
                    .HasConstraintName("FK_OrderRows_Orders");
            });

            modelBuilder.Entity<OrderValue>(entity =>
            {
                entity.HasKey(e => e.IdOrderValues)
                    .HasName("PK_OrderValuesProva");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdOrderRowNavigation)
                    .WithMany(p => p.OrderValues)
                    .HasForeignKey(d => d.IdOrderRow)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderValues_OrderRows");
            });

            modelBuilder.Entity<OrdersTechnicalField>(entity =>
            {
                entity.ToView("OrdersTechnicalField");
            });

            modelBuilder.Entity<PhasesConstraint>(entity =>
            {
                entity.HasKey(e => e.IdPhaseConstraint)
                    .HasName("PK_TaskConstraints");

                entity.HasOne(d => d.IdInputWizardNavigation)
                    .WithMany(p => p.PhasesConstraints)
                    .HasForeignKey(d => d.IdInputWizard)
                    .HasConstraintName("FK_PhasesConstraints_InputWizard");

                entity.HasOne(d => d.IdPhaseCompanyNavigation)
                    .WithMany(p => p.PhasesConstraints)
                    .HasForeignKey(d => d.IdPhaseCompany)
                    .HasConstraintName("FK_PhasesConstraints_PhasesCompany");
            });

            modelBuilder.Entity<PhasesEnginePlanner>(entity =>
            {
                entity.HasKey(e => e.IdPhaseList)
                    .HasName("PK_PhasesEngine");

                entity.Property(e => e.IdPhaseList).ValueGeneratedNever();
            });

            modelBuilder.Entity<PhasesList>(entity =>
            {
                entity.HasKey(e => e.IdPhaseList)
                    .HasName("PK_TasksList");

                entity.HasOne(d => d.IdMachineGroupNavigation)
                    .WithMany(p => p.PhasesLists)
                    .HasForeignKey(d => d.IdMachineGroup)
                    .HasConstraintName("FK_PhasesList_MachineGroup");

                entity.HasOne(d => d.IdPhaseCompanyNavigation)
                    .WithMany(p => p.PhasesLists)
                    .HasForeignKey(d => d.IdPhaseCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhasesList_PhasesCompany");

                entity.HasOne(d => d.IdProcessListNavigation)
                    .WithMany(p => p.PhasesLists)
                    .HasForeignKey(d => d.IdProcessList)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TasksList_ProcessesList");
            });

            modelBuilder.Entity<PhasesMachine>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdMachineNavigation)
                    .WithMany(p => p.PhasesMachines)
                    .HasForeignKey(d => d.IdMachine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhasesMachine_Machine");

                entity.HasOne(d => d.IdPhaseCompanyNavigation)
                    .WithMany(p => p.PhasesMachines)
                    .HasForeignKey(d => d.IdPhaseCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhasesMachine_PhasesCompany");
            });

            modelBuilder.Entity<PhasesSequence>(entity =>
            {
                entity.HasKey(e => e.IdPhaseSequence)
                    .HasName("PK_SequenzaFasi_1");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdMacroProcessesNavigation)
                    .WithMany(p => p.PhasesSequences)
                    .HasForeignKey(d => d.IdMacroProcesses)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhasesSequences_MacroProcesses");

                entity.HasOne(d => d.IdPhaseCompanyNavigation)
                    .WithMany(p => p.PhasesSequences)
                    .HasForeignKey(d => d.IdPhaseCompany)
                    .HasConstraintName("FK_PhasesSequences_PhasesCompany");
            });

            modelBuilder.Entity<PlannerOutput>(entity =>
            {
                entity.Property(e => e.IdPhaseState).IsFixedLength(true);
            });

            modelBuilder.Entity<PresenceDeclaration>(entity =>
            {
                entity.Property(e => e.DeclarationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.OperatorCodeNavigation)
                    .WithMany(p => p.PresenceDeclarations)
                    .HasForeignKey(d => d.OperatorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PresenceDeclarations_Operators");
            });

            modelBuilder.Entity<ProcessesList>(entity =>
            {
                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.ProcessesLists)
                    .HasForeignKey(d => d.IdItem)
                    .HasConstraintName("FK_ProcessesList_Items");

                entity.HasOne(d => d.IdMacroProcessNavigation)
                    .WithMany(p => p.ProcessesLists)
                    .HasForeignKey(d => d.IdMacroProcess)
                    .HasConstraintName("FK_ProcessesList_MacroProcesses");

                entity.HasOne(d => d.IdOrderRowNavigation)
                    .WithMany(p => p.ProcessesLists)
                    .HasForeignKey(d => d.IdOrderRow)
                    .HasConstraintName("FK_ProcessesList_Orders");
            });

            modelBuilder.Entity<ProposalOrder>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdSupplierNavigation)
                    .WithMany(p => p.ProposalOrders)
                    .HasForeignKey(d => d.IdSupplier)
                    .HasConstraintName("FK_Proposal_Suppliers");

                entity.HasOne(d => d.IdWarehouseItemNavigation)
                    .WithMany(p => p.ProposalOrders)
                    .HasForeignKey(d => d.IdWarehouseItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProposalOrder_WarehouseItems");
            });

            modelBuilder.Entity<PurchaseList>(entity =>
            {
                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.PurchaseLists)
                    .HasForeignKey(d => d.IdItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseLists_Items");

                entity.HasOne(d => d.IdSupplierNavigation)
                    .WithMany(p => p.PurchaseLists)
                    .HasForeignKey(d => d.IdSupplier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseLists_Suppliers");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PurchaseOrderRow>(entity =>
            {
                entity.HasKey(e => e.IdPurchaseOrderRow)
                    .HasName("PK_PurchaseOrderRow");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.PurchaseOrderRows)
                    .HasForeignKey(d => d.IdItem)
                    .HasConstraintName("FK_PurchaseOrderRow_Items");

                entity.HasOne(d => d.IdPurchaseOrderParentNavigation)
                    .WithMany(p => p.PurchaseOrderRows)
                    .HasForeignKey(d => d.IdPurchaseOrderParent)
                    .HasConstraintName("FK_PurchaseOrderRow_PurchaseOrder");

                entity.HasOne(d => d.IdSupplierNavigation)
                    .WithMany(p => p.PurchaseOrderRows)
                    .HasForeignKey(d => d.IdSupplier)
                    .HasConstraintName("FK_PurchaseOrderRow_Suppliers");
            });

            modelBuilder.Entity<PurchaseOrderValue>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdPurchaseOrderRowNavigation)
                    .WithMany(p => p.PurchaseOrderValues)
                    .HasForeignKey(d => d.IdPurchaseOrderRow)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseOrderValue_PurchaseOrderRow");
            });

            modelBuilder.Entity<RangeClient>(entity =>
            {
                entity.HasOne(d => d.IdAreaChartRangeNavigation)
                    .WithMany(p => p.RangeClients)
                    .HasForeignKey(d => d.IdAreaChartRange)
                    .HasConstraintName("FK_RangeClient_RangeAreaChart");

                entity.HasOne(d => d.IdChartSeriesNavigation)
                    .WithMany(p => p.RangeClients)
                    .HasForeignKey(d => d.IdChartSeries)
                    .HasConstraintName("FK_RangeClient_ChartSeries");

                entity.HasOne(d => d.IdRangeNavigation)
                    .WithMany(p => p.RangeClients)
                    .HasForeignKey(d => d.IdRange)
                    .HasConstraintName("FK_RangeClient_Range");
            });

            modelBuilder.Entity<RibbonsPage>(entity =>
            {
                entity.Property(e => e.RibbonPageImage).IsUnicode(false);

                entity.Property(e => e.RibbonPageName).IsUnicode(false);

                entity.Property(e => e.RibbonPageTitle).IsUnicode(false);
            });

            modelBuilder.Entity<RibbonsPageGroup>(entity =>
            {
                entity.Property(e => e.RibbonPageGroupName).IsUnicode(false);

                entity.Property(e => e.RibbonPageGroupTitle).IsUnicode(false);

                entity.HasOne(d => d.IdRibbonPageNavigation)
                    .WithMany(p => p.RibbonsPageGroups)
                    .HasForeignKey(d => d.IdRibbonPage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToolbarRibbonGroups_ToolbarRibbons");
            });

            modelBuilder.Entity<RibbonsPageGroupButton>(entity =>
            {
                entity.Property(e => e.RibbonPageGroupButtonImage).IsUnicode(false);

                entity.Property(e => e.RibbonPageGroupButtonName).IsUnicode(false);

                entity.Property(e => e.RibbonPageGroupButtonTitle).IsUnicode(false);
            });

            modelBuilder.Entity<SalesList>(entity =>
            {
                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.SalesLists)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesLists_Customers");

                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.SalesLists)
                    .HasForeignKey(d => d.IdItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesLists_Items");
            });

            modelBuilder.Entity<SalesPrice>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdOrderRowNavigation)
                    .WithMany(p => p.SalesPrices)
                    .HasForeignKey(d => d.IdOrderRow)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesPrices_OrderRows");
            });

            modelBuilder.Entity<Scheduler>(entity =>
            {
                entity.Property(e => e.CurrentDate).IsUnicode(false);

                entity.Property(e => e.SchedulerName).IsUnicode(false);

                entity.Property(e => e.SchedulerTitle).IsUnicode(false);
            });

            modelBuilder.Entity<SchedulerAppointmentMapping>(entity =>
            {
                entity.HasKey(e => e.IdAppointmentMapping)
                    .HasName("PK_SchedulersAppointmentMapping");

                entity.HasOne(d => d.IdSchedulerNavigation)
                    .WithMany(p => p.SchedulerAppointmentMappings)
                    .HasForeignKey(d => d.IdScheduler)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SchedulersAppointmentMapping_Schedulers");
            });

            modelBuilder.Entity<SchedulerDependencyMapping>(entity =>
            {
                entity.HasOne(d => d.IdSchedulerNavigation)
                    .WithMany(p => p.SchedulerDependencyMappings)
                    .HasForeignKey(d => d.IdScheduler)
                    .HasConstraintName("FK_SchedulerDependencyMappings_Schedulers");
            });

            modelBuilder.Entity<SchedulerFlyoutAppointment>(entity =>
            {
                entity.Property(e => e.BackColor).IsUnicode(false);

                entity.Property(e => e.Font).IsUnicode(false);

                entity.Property(e => e.ForeColor).IsUnicode(false);

                entity.HasOne(d => d.IdSchedulerNavigation)
                    .WithMany(p => p.SchedulerFlyoutAppointments)
                    .HasForeignKey(d => d.IdScheduler)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SchedulerFlyoutAppointment_Schedulers");
            });

            modelBuilder.Entity<SchedulerResourceMapping>(entity =>
            {
                entity.HasOne(d => d.IdSchedulerNavigation)
                    .WithMany(p => p.SchedulerResourceMappings)
                    .HasForeignKey(d => d.IdScheduler)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SchedulerResourceMapping_Schedulers");
            });

            modelBuilder.Entity<SettingItemWorkingShapeCode>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<SettingType>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<SettingsMaterial>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TimbratoreSetup>(entity =>
            {
                entity.HasOne(d => d.IdParentNavigation)
                    .WithMany(p => p.InverseIdParentNavigation)
                    .HasForeignKey(d => d.IdParent)
                    .HasConstraintName("FK_TimbratoreSetup_TimbratoreSetup1");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.IdItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Track_Items");

                entity.HasOne(d => d.IdOrderRowNavigation)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.IdOrderRow)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NF_OrderRows");
            });

            modelBuilder.Entity<UnitLetter>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ViewBom>(entity =>
            {
                entity.ToView("ViewBoms");
            });

            modelBuilder.Entity<ViewDepartmentOpenProcess>(entity =>
            {
                entity.ToView("viewDepartmentOpenProcesses");
            });

            modelBuilder.Entity<ViewDurataCommesse>(entity =>
            {
                entity.ToView("ViewDurataCommesse");
            });

            modelBuilder.Entity<ViewOperatoriPresenze>(entity =>
            {
                entity.ToView("ViewOperatoriPresenze");
            });

            modelBuilder.Entity<ViewPartsRequestForBom>(entity =>
            {
                entity.ToView("ViewPartsRequestForBoms");
            });

            modelBuilder.Entity<ViewProcessDocument>(entity =>
            {
                entity.ToView("ViewProcessDocument");
            });

            modelBuilder.Entity<ViewProcessi>(entity =>
            {
                entity.ToView("ViewProcessi");
            });

            modelBuilder.Entity<ViewTimeLine>(entity =>
            {
                entity.ToView("ViewTimeLine");

                entity.Property(e => e.FaseProcesso).IsUnicode(false);
            });

            modelBuilder.Entity<ViewTimeLine1>(entity =>
            {
                entity.ToView("ViewTimeLine1");

                entity.Property(e => e.FaseProcesso).IsUnicode(false);
            });

            modelBuilder.Entity<ViewTimestepGrid>(entity =>
            {
                entity.ToView("ViewTimestepGrid");
            });

            modelBuilder.Entity<ViewWareHouseStatus>(entity =>
            {
                entity.ToView("ViewWareHouseStatus");

                entity.Property(e => e.Supplier).IsUnicode(false);
            });

            modelBuilder.Entity<WarehouseItem>(entity =>
            {
                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.WarehouseItems)
                    .HasForeignKey(d => d.IdItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WareHouseItems_ItemRecords");

                entity.HasOne(d => d.IdLocationNavigation)
                    .WithMany(p => p.WarehouseItems)
                    .HasForeignKey(d => d.IdLocation)
                    .HasConstraintName("FK_WareHouseItems_WareHouseLocations");
            });

            modelBuilder.Entity<WarehouseMovement>(entity =>
            {
                entity.Property(e => e.MovementDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdOrderRowNavigation)
                    .WithMany(p => p.WarehouseMovements)
                    .HasForeignKey(d => d.IdOrderRow)
                    .HasConstraintName("FK_WareHouseMovements_Orders");

                entity.HasOne(d => d.IdProposalNavigation)
                    .WithMany(p => p.WarehouseMovements)
                    .HasForeignKey(d => d.IdProposal)
                    .HasConstraintName("FK_WareHouseMovements_Proposal");

                entity.HasOne(d => d.IdWareHouseItemNavigation)
                    .WithMany(p => p.WarehouseMovements)
                    .HasForeignKey(d => d.IdWareHouseItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WareHouseMovements_WareHouseItems");
            });

            modelBuilder.Entity<WarehouseMovementDocument>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdDocumentNavigation)
                    .WithMany(p => p.WarehouseMovementDocuments)
                    .HasForeignKey(d => d.IdDocument)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WareHouseMovementDocuments_WareHouseDocuments");

                entity.HasOne(d => d.IdWareHouseMovementNavigation)
                    .WithMany(p => p.WarehouseMovementDocuments)
                    .HasForeignKey(d => d.IdWareHouseMovement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WareHouseMovementDocuments_WareHouseMovements");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
