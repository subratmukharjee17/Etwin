using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class OrderParameter
    {
        [Key]
        public int IdOrderParameter { get; set; }
        public int IdValueType { get; set; }
        [Required]
        [Column("OrderParameter")]
        [StringLength(50)]
        public string OrderParameter1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdValueType))]
        [InverseProperty(nameof(ValueType.OrderParameters))]
        public virtual ValueType IdValueTypeNavigation { get; set; }
    }
}
