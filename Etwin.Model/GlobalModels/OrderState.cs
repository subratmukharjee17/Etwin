using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class OrderState
    {
        [Key]
        public int IdOrderState { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }
    }
}
