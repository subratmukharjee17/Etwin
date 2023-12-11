using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Etwin.Model
{
    public partial class Item
    {
        public Item()
        {
            BomPhases = new HashSet<BomPhase>();
            Boms = new HashSet<Bom>();
            ItemGraphicComponents = new HashSet<ItemGraphicComponent>();
            ItemValues = new HashSet<ItemValue>();
            OrderRows = new HashSet<OrderRow>();
            ProcessesLists = new HashSet<ProcessesList>();
            PurchaseLists = new HashSet<PurchaseList>();
            PurchaseOrderRows = new HashSet<PurchaseOrderRow>();
            SalesLists = new HashSet<SalesList>();
            Tracks = new HashSet<Track>();
            WarehouseItems = new HashSet<WarehouseItem>();
        }

        [Key]
        public int IdItem { get; set; }
        public int? IdSettingType { get; set; }
        [StringLength(50)]
        public string ItemCode { get; set; }
        [StringLength(50)]
        public string ItemDescription { get; set; }
        public int? Revision { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreationDate { get; set; }

        [ForeignKey(nameof(IdSettingType))]
        [InverseProperty(nameof(SettingType.Items))]
        public virtual SettingType IdSettingTypeNavigation { get; set; }
        [InverseProperty(nameof(BomPhase.IdItemNavigation))]
        public virtual ICollection<BomPhase> BomPhases { get; set; }
        [InverseProperty(nameof(Bom.IdItemNavigation))]
        public virtual ICollection<Bom> Boms { get; set; }
        [InverseProperty(nameof(ItemGraphicComponent.IdItemNavigation))]
        public virtual ICollection<ItemGraphicComponent> ItemGraphicComponents { get; set; }
        [InverseProperty(nameof(ItemValue.IdItemNavigation))]
        public virtual ICollection<ItemValue> ItemValues { get; set; }
        [InverseProperty(nameof(OrderRow.IdItemNavigation))]
        public virtual ICollection<OrderRow> OrderRows { get; set; }
        [InverseProperty(nameof(ProcessesList.IdItemNavigation))]
        public virtual ICollection<ProcessesList> ProcessesLists { get; set; }
        [InverseProperty(nameof(PurchaseList.IdItemNavigation))]
        public virtual ICollection<PurchaseList> PurchaseLists { get; set; }
        [InverseProperty(nameof(PurchaseOrderRow.IdItemNavigation))]
        public virtual ICollection<PurchaseOrderRow> PurchaseOrderRows { get; set; }
        [InverseProperty(nameof(SalesList.IdItemNavigation))]
        public virtual ICollection<SalesList> SalesLists { get; set; }
        [InverseProperty(nameof(Track.IdItemNavigation))]
        public virtual ICollection<Track> Tracks { get; set; }
        [InverseProperty(nameof(WarehouseItem.IdItemNavigation))]
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; }
    }
}
