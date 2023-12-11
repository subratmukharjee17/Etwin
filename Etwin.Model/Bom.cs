using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class Bom
    {
        public Bom()
        {
            InverseIdMainBomNavigation = new HashSet<Bom>();
        }

        [Key]
        public int Id { get; set; }
        public int? IdBomParent { get; set; }
        public int IdDepartment { get; set; }
        public int IdBomType { get; set; }
        public int IdMeasureUnit { get; set; }
        public int? IdItem { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Quantity { get; set; }
        [Required]
        [StringLength(50)]
        public string BomCode { get; set; }
        [StringLength(200)]
        public string BomDescription { get; set; }
        public int? BomLevel { get; set; }
        public int? IdMainBom { get; set; }
        [StringLength(50)]
        public string DrawingNumber { get; set; }
        [StringLength(400)]
        public string Note { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdItem))]
        [InverseProperty(nameof(Item.Boms))]
        public virtual Item IdItemNavigation { get; set; }
        [ForeignKey(nameof(IdMainBom))]
        [InverseProperty(nameof(Bom.InverseIdMainBomNavigation))]
        public virtual Bom IdMainBomNavigation { get; set; }
        [InverseProperty(nameof(Bom.IdMainBomNavigation))]
        public virtual ICollection<Bom> InverseIdMainBomNavigation { get; set; }
    }
}
