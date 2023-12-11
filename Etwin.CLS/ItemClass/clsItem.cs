using Etwin.BAL.BusinnessLogic;
using Etwin.BAL.BusinnessLogic.BLGenericDB;
using Etwin.Helper.DerivedItems;
using ETwin.BAL.FixModels;
using Etwin.Model;
using LogDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Etwin.Model.GlobalModels;
using Etwin.BAL.BusinnessLogic.BLGlobalDB;

namespace Etwin.CLS.ItemClass
{
    public class clsItem
    {
        #region VARS
        private readonly BlItems blItems = new BlItems();
        private readonly BlItemParameter blItemParameter = new BlItemParameter();
        #endregion

        #region SET CHILD
        /// <summary>
        /// CREATION CHILDREN BY ID BOM PARENT
        /// </summary>
        /// <param name="idBom"></param>
        /// <returns></returns>
        public IList<Bom> SetChild(int idBom)
        {
            IList<Bom> lstBomAdd = new List<Bom>();
            try
            {
                //BlGeneralSettingActive blGeneralSettingActive= new BlGeneralSettingActive();
                //GeneralSettingActive detail = blGeneralSettingActive.GetGeneralSettingActive(1);
                //if (detail.Value == true)
                //{

                //I'll take the bom father, BOM PARENT ALREADY INSERTED
                BlBom blBom = new BlBom();
                Bom bom = blBom.GetBomById(idBom);
                IList<ItemParameter> lstParameter = new List<ItemParameter>();

                BlItemValue blItemValue = new BlItemValue();
                if (bom.IdItem != null)
                {
                    //GET ITEM VALUE OF ITEM ALREADY INSERTED
                    IList<ItemValue> lstValue = blItemValue.GetItemValueByItem((int)bom.IdItem);

                    //LOOP ITEM VALUE
                    foreach (ItemValue itemValue in lstValue)
                    {
                        //ADD TO lstParameter THE PARAMETERS WITH A VALUE
                        ItemParameter itemParameter = this.blItemParameter.GetItemParameter(itemValue.IdItemParameterCompany);
                        lstParameter.Add(itemParameter);

                    }
                }
                //CHECK IF THERE ARE SOME PARAMETERS
                if (lstParameter.Count > 0)
                {
                    //GET TYPE OF PARAMETERS (Tube, fin,...)
                    IList<ItemType> lstParameterType = this.GetParameterType(lstParameter);

                    foreach (ItemType type in lstParameterType)
                    {
                        //GET MATERIAL
                        ItemParameter RowTypeMaterial = this.blItemParameter.GetLinkType(lstParameterType.Where(x => x.Id == type.Id).First().Type);
                        if (RowTypeMaterial != null && RowTypeMaterial.IdItemParameter != 0)
                        {
                            //I add the bom
                            Item i = this.AddItemNotPresent();
                            i = SetItemName(i);

                            Bom bomToAdd = new Bom();
                            bomToAdd.IdBomParent = bom.Id;
                            bomToAdd.IdDepartment = bom.IdDepartment;
                            bomToAdd.IdBomType = bom.IdBomType;
                            bomToAdd.IdMeasureUnit = bom.IdMeasureUnit;
                            bomToAdd.Quantity = bom.Quantity;
                            bomToAdd.BomCode = i.ItemCode;
                            bomToAdd.BomLevel = bom.BomLevel + 1;
                            bomToAdd.IdMainBom = bom.IdMainBom;
                            bomToAdd.IdItem = i.IdItem;

                            blBom.AddBom(bomToAdd);
                            lstBomAdd.Add(bomToAdd);
                        }
                    }
                    //}
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstBomAdd;
        }
        #endregion

        public Item AddItemNotPresent()
        {
            Item item = new Item();
            try
            {
                item.ItemCode = "Provvisorio";
                blItems.AddItem(item);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return item;
        }

        #region SET ITEM NAME
        public Item SetItemName(Item item)
        {
            Item i = new Item();
            try
            {
                string itemcode = String.Empty;

                itemcode = blItems.SetItemCode(item.IdItem);

                if (!string.IsNullOrEmpty(itemcode))
                {
                    i = blItems.GetIdByItemCode(itemcode);
                    if (i.IdItem == null)
                    {
                        item.ItemCode = itemcode;
                        blItems.UpdateItem(item);
                        i = item;
                    }
                    else
                    {
                        blItems.DeleteItem(item);
                    }
                }

            }
            catch (Exception ex)
            {

                clsLog.Error(ex.ToString());
            }
            return i;
        }
        #endregion

        private IList<ItemType> GetParameterType(IList<ItemParameter> parameters)
        {
            IList<ItemType> lstParameterType = new List<ItemType>();
            IList<ItemType> lstExistingType = new List<ItemType>();
            try
            {
                //I TAKE THE LIST OF TYPES
                lstParameterType = blItemParameter.GetItemType();


                //LOOP FOR PARAMETERS
                foreach (ItemParameter bomParameter in parameters)
                {
                    if (parameters.Count() == 1)
                    {
                        ItemParameter mod = parameters[0];
                        if (mod.IdItemType != null)
                        {

                            ItemType itemType = lstParameterType.Where(x => x.Id == mod.IdItemType).FirstOrDefault();
                            if (itemType != null)
                            {
                                if (!lstExistingType.Contains(itemType) && itemType != null)
                                {
                                    lstExistingType.Add(itemType);
                                    if (itemType.IdTypeParent != null)
                                    {
                                        ItemType itemTypeChild = lstParameterType.Where(y => y.Id == itemType.IdTypeParent).FirstOrDefault();
                                        if (!lstExistingType.Contains(itemTypeChild))
                                        {
                                            lstExistingType.Add(itemTypeChild);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstExistingType;
        }
    }
}
