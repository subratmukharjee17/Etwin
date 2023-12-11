using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("CompanyTheme")]
    public partial class CompanyTheme
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string ThemeName { get; set; }
        [StringLength(50)]
        public string ThemeClass { get; set; }
    }
}
