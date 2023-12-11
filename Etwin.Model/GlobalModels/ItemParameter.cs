using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model.GlobalModels
{
    public partial class ItemParameter
    {
        public ItemParameter()
        {
            PhasesItemParameters = new HashSet<PhasesItemParameter>();
        }

        [Key]
        public int IdItemParameter { get; set; }
        public string ItemParameterName { get; set; }
        public string ItemParameterDescription { get; set; }
        public int? IdItemType { get; set; }
        public int? IdValueType { get; set; }
        public string Calculation { get; set; }
        [StringLength(10)]
        public string ExecutionOrder { get; set; }
        public bool? IsFilter { get; set; }
        public string FilterCommand { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(IdItemType))]
        [InverseProperty(nameof(ItemType.ItemParameters))]
        public virtual ItemType IdItemTypeNavigation { get; set; }
        [ForeignKey(nameof(IdValueType))]
        [InverseProperty(nameof(ValueType.ItemParameters))]
        public virtual ValueType IdValueTypeNavigation { get; set; }
        [InverseProperty(nameof(PhasesItemParameter.IdItemParameterNavigation))]
        public virtual ICollection<PhasesItemParameter> PhasesItemParameters { get; set; }
    }
}
