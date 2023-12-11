using Etwin.BAL.BusinnessLogic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using LogDll;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Etwin.Model;
using System;
using System.Collections.Generic;
namespace Etwin.BAL.ControllersEtwin
{
    
    public class ItemsController : ControllerBase
    {
        #region VARS
        private readonly IConfiguration _config = null;

        private readonly ILogger<ItemsController> _logger;
        private readonly BlItems blItems = null;

        #endregion

        public ItemsController(ILogger<ItemsController> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
            this.blItems = new BlItems(this._config.GetSection("ConnectionStrings").GetSection("MbkDbConstr").Value);
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetItems/{idItems}")]
        public async Task<BindingList<Item>> GetItems(int idItems)
        {
            BindingList<Item> bindingListItems = new BindingList<Item>();
            try
            {
                bindingListItems = this.blItems.GetItems(idItems);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return bindingListItems;
        }

        [HttpGet]
        [AcceptVerbs("GET")]
        [Route("api/GetAllItems/")]
        public async Task<IList<Item>> GetAllItems()
        {
            IList<Item> lstItems = new List<Item>();
            try
            {
                lstItems = this.blItems.GetAllItems();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstItems;
        }

        [HttpPost]
        [AcceptVerbs("POST")]
        [Route("api/AddItem/{item}")]
        public async Task AddItem(Item item)
        {
            try
            {
                this.blItems.AddItem(item);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }

        [HttpPut]
        [AcceptVerbs("PUT")]
        [Route("api/UpdateItem/{item}")]
        public async Task UpdateItem(Item item)
        {
            this.blItems.UpdateItem(item);
        }

        [HttpDelete]
        [AcceptVerbs("DELETE")]
        [Route("api/DeleteItem/{item}")]
        public async Task DeleteItem(Item item)
        {
            this.blItems.DeleteItem(item);
        }
    }
}