using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("TaxCode")]
    public partial class TaxCode
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public int Rate { get; set; }
        public bool? Deductible { get; set; }
        public bool? Billable { get; set; }
    }
}
