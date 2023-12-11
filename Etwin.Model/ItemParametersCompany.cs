using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("ItemParametersCompany")]
    public partial class ItemParametersCompany
    {
        public ItemParametersCompany()
        {
            ItemValues = new HashSet<ItemValue>();
        }

        [Key]
        public int IdItemParameterCompany { get; set; }
        public int IdItemParameterGlobal { get; set; }
        [Required]
        [StringLength(70)]
        public string ItemParameterName { get; set; }
        public int? ExecutionOrder { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [InverseProperty(nameof(ItemValue.IdItemParameterCompanyNavigation))]
        public virtual ICollection<ItemValue> ItemValues { get; set; }
    }
}
