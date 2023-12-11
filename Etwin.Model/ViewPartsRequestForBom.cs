using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Keyless]
    public partial class ViewPartsRequestForBom
    {
        public int? Id { get; set; }
        [StringLength(50)]
        public string BomCode { get; set; }
        public string PartNumber { get; set; }
        [StringLength(5)]
        public string BomMeasure { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RequestQuantity { get; set; }
        [StringLength(5)]
        public string WareHouseMeasure { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? WareHouseQuantity { get; set; }
        [Column("PartOK")]
        public int PartOk { get; set; }
        [Column(TypeName = "decimal(19, 2)")]
        public decimal? PartDeficit { get; set; }
    }
}
