using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Keyless]
    public partial class ViewBom
    {
        [StringLength(50)]
        public string Type { get; set; }
        [StringLength(50)]
        public string BomCode { get; set; }
        public string BomDescription { get; set; }
        public int? BomLevel { get; set; }
        [StringLength(5)]
        public string MeasureBom { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? QuantityBom { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Cost { get; set; }
        public string PartNumber { get; set; }
        [StringLength(256)]
        public string PartName { get; set; }
        [StringLength(512)]
        public string PartDescription { get; set; }
        [StringLength(5)]
        public string MeasureItem { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? QuantityItem { get; set; }
        [Column(TypeName = "decimal(37, 4)")]
        public decimal? CalculatedCost { get; set; }
        public string Image { get; set; }
        public string Note { get; set; }
        [StringLength(256)]
        public string Fase { get; set; }
        [StringLength(256)]
        public string WareHouseName { get; set; }
        public string WareHouseType { get; set; }
        [StringLength(256)]
        public string Location { get; set; }
        public string LocationDescription { get; set; }
        [StringLength(150)]
        public string ProjectCode { get; set; }
        [StringLength(150)]
        public string ProjectDescription { get; set; }
    }
}
