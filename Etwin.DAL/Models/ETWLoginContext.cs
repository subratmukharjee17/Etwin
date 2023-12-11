using Etwin.DAL.Models;
using Etwin.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Etwin.DAL.Model
{
    public class ETWLoginContext:DbContext

    {
        
        public ETWLoginContext(DbContextOptions<ETWLoginContext> options) : base(options)
        {

        }
      
     
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OperatorInfo>(entity => {
                entity.HasKey(k => k.OperatorCode);
            });
            builder.Entity<RibbonsPages>().ToTable("RibbonsPages", schema: "ETwin");
            builder.Entity<RibbonsPageGroups>().ToTable("RibbonsPageGroups", schema: "ETwin");
            builder.Entity<RibbonsPageGroupButtons>().ToTable("RibbonsPageGroupButtons", schema: "ETwin");
            builder.Entity<Bands>().ToTable("Bands", schema: "ETwin");
            builder.Entity<GridsColumns>().ToTable("GridsColumns", schema: "ETwin");
            builder.Entity<Charts>().ToTable("Charts", schema: "ETwin");
        }

        public DbSet<OperatorInfo> OperatorInfo { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<RibbonsPages> RibbonsPages { get; set; }
        public DbSet<RibbonsPageGroups> RibbonsPageGroups { get; set; }
        public DbSet<DepartmentAccess> DepartmentAccess { get; set; }
        public DbSet<Bands> Bands { get; set; }
        public DbSet<GridsColumns> BlackHeader { get; set; }
        public DbSet<Charts> Charts { get; set; }

        public virtual DbQuery<ReportChartModeList> ReportChartModel { get; set; }
        public virtual DbQuery<ReportOrderWithPhaseList> ReportOrderWithPhaseListModel { get; set; }
        public virtual DbQuery<ReportModeList> ReportModel { get; set; }
    }
}
