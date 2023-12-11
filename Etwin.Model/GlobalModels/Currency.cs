using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("Currency")]
    public partial class Currency
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [StringLength(50)]
        public string Symbol { get; set; }
    }
}
