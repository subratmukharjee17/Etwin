using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("ProposalState")]
    public partial class ProposalState
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
