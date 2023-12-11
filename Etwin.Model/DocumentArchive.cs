using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    [Table("DocumentArchive")]
    public partial class DocumentArchive
    {
        public DocumentArchive()
        {
            DocumentArchiveValues = new HashSet<DocumentArchiveValue>();
        }

        [Key]
        public int Id { get; set; }
        public int IdDocumentType { get; set; }
        [Required]
        [StringLength(200)]
        public string FileName { get; set; }
        [StringLength(400)]
        public string FullPathEtwin { get; set; }
        [StringLength(400)]
        public string FullPathCompany { get; set; }
        [StringLength(50)]
        public string FileDimension { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FileCreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifyDate { get; set; }
        public byte[] Content { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [InverseProperty(nameof(DocumentArchiveValue.IdDocumentArchiveNavigation))]
        public virtual ICollection<DocumentArchiveValue> DocumentArchiveValues { get; set; }
    }
}
