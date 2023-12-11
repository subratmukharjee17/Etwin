using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class PhasesListState
    {
        [Key]
        public int IdPhaseListState { get; set; }
        public string PhaseListState { get; set; }
    }
}
