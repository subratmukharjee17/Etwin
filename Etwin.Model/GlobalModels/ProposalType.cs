using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("ProposalType")]
    public partial class ProposalType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
