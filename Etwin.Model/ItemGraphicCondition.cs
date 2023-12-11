using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class ItemGraphicCondition
    {
        [Key]
        public int Id { get; set; }
        public int IdItemType { get; set; }
        [Required]
        public string Condition { get; set; }
    }
}
