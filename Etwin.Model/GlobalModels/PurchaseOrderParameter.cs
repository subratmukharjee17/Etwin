using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Keyless]
    public partial class PurchaseOrderParameter
    {
        public int Id { get; set; }
        public int IdValueType { get; set; }
        [Required]
        [Column("PurchaseOrderParameter")]
        [StringLength(50)]
        public string PurchaseOrderParameter1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdValueType))]
        public virtual ValueType IdValueTypeNavigation { get; set; }
    }
}
