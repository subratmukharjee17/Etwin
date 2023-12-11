using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    [Table("ValueType")]
    public partial class ValueType
    {
        public ValueType()
        {
            DeclarationParameters = new HashSet<DeclarationParameter>();
            DocumentArchiveParameters = new HashSet<DocumentArchiveParameter>();
            ItemParameters = new HashSet<ItemParameter>();
            MachineDeclarationParameters = new HashSet<MachineDeclarationParameter>();
            OperatorParameters = new HashSet<OperatorParameter>();
            OrderParameters = new HashSet<OrderParameter>();
            TraceabilityParameters = new HashSet<TraceabilityParameter>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string ColumnValueType { get; set; }

        [InverseProperty(nameof(DeclarationParameter.IdValueTypeNavigation))]
        public virtual ICollection<DeclarationParameter> DeclarationParameters { get; set; }
        [InverseProperty(nameof(DocumentArchiveParameter.IdValueTypeNavigation))]
        public virtual ICollection<DocumentArchiveParameter> DocumentArchiveParameters { get; set; }
        [InverseProperty(nameof(ItemParameter.IdValueTypeNavigation))]
        public virtual ICollection<ItemParameter> ItemParameters { get; set; }
        [InverseProperty(nameof(MachineDeclarationParameter.IdValueTypeNavigation))]
        public virtual ICollection<MachineDeclarationParameter> MachineDeclarationParameters { get; set; }
        [InverseProperty(nameof(OperatorParameter.IdValueTypeNavigation))]
        public virtual ICollection<OperatorParameter> OperatorParameters { get; set; }
        [InverseProperty(nameof(OrderParameter.IdValueTypeNavigation))]
        public virtual ICollection<OrderParameter> OrderParameters { get; set; }
        [InverseProperty(nameof(TraceabilityParameter.IdValueTypeNavigation))]
        public virtual ICollection<TraceabilityParameter> TraceabilityParameters { get; set; }
    }
}
