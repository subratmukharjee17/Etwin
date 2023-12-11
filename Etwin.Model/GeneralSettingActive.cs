using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("GeneralSettingActive")]
    public partial class GeneralSettingActive
    {
        [Key]
        public int Id { get; set; }
        public int IdGeneralSetting { get; set; }
        public int IdProgramVerison { get; set; }
        public bool Active { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public bool Value { get; set; }
    }
}
