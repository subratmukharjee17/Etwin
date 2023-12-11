using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class MachineState
    {
        [Key]
        public int IdMachineState { get; set; }
        [Column("MachineState")]
        public string MachineState1 { get; set; }
    }
}
