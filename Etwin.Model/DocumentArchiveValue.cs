using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class DocumentArchiveValue
    {
        [Key]
        public int Id { get; set; }
        public int IdDocumentArchive { get; set; }
        public int IdDocumentArchiveParameter { get; set; }
        [Required]
        public string Value { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdDocumentArchive))]
        [InverseProperty(nameof(DocumentArchive.DocumentArchiveValues))]
        public virtual DocumentArchive IdDocumentArchiveNavigation { get; set; }
    }
}
