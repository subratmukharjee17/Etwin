using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Keyless]
    public partial class OrdersTechnicalField
    {
        public int IdOrder { get; set; }
        public int IdProject { get; set; }
        public int IdOrderType { get; set; }
        public int IdOrderStates { get; set; }
        public int IdCustomer { get; set; }
        [Required]
        [StringLength(15)]
        public string Order { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeliveryDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [StringLength(150)]
        public string OrderQty { get; set; }
        [Column("disegno")]
        public string Disegno { get; set; }
        [Column("modello")]
        public string Modello { get; set; }
        public double? T { get; set; }
        public double? R { get; set; }
        public double? A { get; set; }
        public double? P { get; set; }
        [Column("NC")]
        public double? Nc { get; set; }
        public string MaterialeTubi { get; set; }
        public string MaterialeAlette { get; set; }
        public string MaterialeTelaio { get; set; }
        public string MaterialeCollettori { get; set; }
        public string MaterialeRaccorderia { get; set; }
        public double? DiametroTubi { get; set; }
        public double? SpessoreTubi { get; set; }
        public double? AltezzaAletta { get; set; }
        public double? SpessoreAletta { get; set; }
        public string Tipologia { get; set; }
        public double? SviluppoTubiero { get; set; }
        public double? SviluppoAlettato { get; set; }
        [Column("N°camini", TypeName = "decimal(10, 0)")]
        public decimal? NCamini { get; set; }
        [Column("N°strutture", TypeName = "decimal(10, 0)")]
        public decimal? NStrutture { get; set; }
        [Column("N°gambe", TypeName = "decimal(10, 0)")]
        public decimal? NGambe { get; set; }
        [Column("DATA MODIFICA", TypeName = "datetime")]
        public DateTime? DataModifica { get; set; }
    }
}
