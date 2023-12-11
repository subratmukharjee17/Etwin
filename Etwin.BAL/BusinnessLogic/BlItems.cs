using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.ComponentModel;
using LogDll;
using System.Linq.Expressions;
using Etwin.Model.Context;
using Newtonsoft.Json;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlItems : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlItems(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }


        public BindingList<Item> GetItems(int idItems)
        {
            IList<Item> lstItems = new List<Item>();
            BindingList<Item> bindingListItems = new BindingList<Item>();
            try
            {
                Expression<Func<Item, bool>> expr = e => e.IdItem == idItems;

                lstItems = this.unitOfWork.Items.GetAll(expr).ToList();
                bindingListItems = new BindingList<Item>(lstItems);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bindingListItems;
        }

        public Item GetIdByItemCode(string nomeDisegno)
        {
            Item i = new Item();
            try
            {
                Expression<Func<Item, bool>> expr = e => e.ItemCode == nomeDisegno;

                i = this.unitOfWork.Items.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return i;
        }

        public IList<Item> GetAllItems()
        {
            IList<Item> lstItems = new List<Item>();
            try
            {
                lstItems = this.unitOfWork.Items.GetAll().ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstItems;
        }

        //public IList<Item> GetItemsByIdOrder(int idOrder)
        //{
        //    IList<Item> lstItems = new List<Item>();
        //    try
        //    {
        //        Expression<Func<Item, bool>> expr = e => e.IdOrder == idOrder;
        //        lstItems = this.unitOfWork.Items.GetAll(expr).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLog.Error(ex.ToString());
        //    }
        //    return lstItems;
        //}

        public Item GetItem(int idItem)
        {
            Item i = new Item();
            try
            {
                Expression<Func<Item, bool>> expr = e => e.IdItem == idItem;
                i = this.unitOfWork.Items.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return i;
        }

        public string SetItemCode(int idItem)
        {
            string code = String.Empty;
            try
            {
                using (SP_Call sp = new SP_Call(this._db))
                {
                    // SP PARAMETER: idCommessa
                    Dapper.DynamicParameters dP = new Dapper.DynamicParameters();
                    dP.Add("IdItem", idItem);
                    // CALL SP : RITORNA UNA STRINGA JSON CON I PARAMETRI COMMESSA IN FORMATO COLONNE, NON RIGHE
                    string valoriCommessaJson = sp.OneRecordJson("TalkingCoding", dP);
                    var keyValueList = JsonConvert.DeserializeObject<dynamic>(valoriCommessaJson);

                    // Crea una lista di oggetti KeyValuePair<string, string> dai dati deserializzati
                    KeyValuePair<string, string> keyValuePairs = new KeyValuePair<string, string>();
                    code = ((Newtonsoft.Json.Linq.JContainer)((Newtonsoft.Json.Linq.JContainer)keyValueList.First).First).Last.ToString();
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return code;
        }

        public void AddItem(Item item)
        {
            try
            {
                this.unitOfWork.Items.Add(item);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public void UpdateItem(Item item)
        {
            try
            {
                this.unitOfWork.Items.Update(item);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public void DeleteItem(Item item)
        {
            try
            {
                this.unitOfWork.Items.Remove(item);
                this.unitOfWork.Save();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
