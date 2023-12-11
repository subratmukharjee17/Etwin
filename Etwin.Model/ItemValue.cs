using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class ItemValue
    {
        [Key]
        public int IdItemValues { get; set; }
        public int IdItem { get; set; }
        public int IdItemParameterCompany { get; set; }
        [Required]
        [Column("ItemValue")]
        [StringLength(50)]
        public string ItemValue1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdItem))]
        [InverseProperty(nameof(Item.ItemValues))]
        public virtual Item IdItemNavigation { get; set; }
        [ForeignKey(nameof(IdItemParameterCompany))]
        [InverseProperty(nameof(ItemParametersCompany.ItemValues))]
        public virtual ItemParametersCompany IdItemParameterCompanyNavigation { get; set; }
    }
}
