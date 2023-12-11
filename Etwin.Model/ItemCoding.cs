using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("ItemCoding")]
    public partial class ItemCoding
    {
        [Key]
        public int Id { get; set; }
        public int? IdSettingType { get; set; }
        public int Chars { get; set; }
        [Required]
        public string Category { get; set; }
        public int Sequence { get; set; }
        public bool Enable { get; set; }
        public string SqlQuery { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreazionDate { get; set; }

        [ForeignKey(nameof(IdSettingType))]
        [InverseProperty(nameof(SettingType.ItemCodings))]
        public virtual SettingType IdSettingTypeNavigation { get; set; }
    }
}
