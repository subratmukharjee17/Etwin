using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class PhaseActivity
    {
        [Key]
        public int IdPhaseActivity { get; set; }
        public string PhaseActivityDescription { get; set; }
    }
}
