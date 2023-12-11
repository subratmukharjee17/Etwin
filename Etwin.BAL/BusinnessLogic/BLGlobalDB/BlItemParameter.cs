using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Etwin.DAL.GlobalDataRepository;
using Etwin.DAL.GlobalDataRepository.IRepository;
using Etwin.Model.Context;
using Etwin.Model.GlobalModels;
using ETwin.BAL.FixModels;
using LogDll;

namespace Etwin.BAL.BusinnessLogic.BLGlobalDB
{
    public class BlItemParameter : IDisposable
    {
        #region VARS
        IUnitOfWork unitOfWork = null;
        private readonly GlobalDbContext _db;
        #endregion

        #region CONSTRUCTOR
        public BlItemParameter()
        {
            this._db = new GlobalDbContext();
            this.unitOfWork = new UnitOfWork(_db);
        }
        #endregion

        #region GET ITEM TYPE
        public IList<ItemType> GetItemType(string? type = null)
        {
            IList<ItemType> lstItemType = new List<ItemType>();
            try
            {
                Expression<Func<ItemType, bool>> expr = null;
                if (!string.IsNullOrEmpty(type) )
                {
                    expr = e => e.Type.Equals(type);

                }
                lstItemType = this.unitOfWork.ItemType.GetAll(expr).ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return lstItemType;
        }
        #endregion

        #region GET ITEM TYPE PARENT
        public ItemParameter GetLinkType(string type)
        {
            ItemParameter param = new ItemParameter();
            try
            {
                //GET ITEM TYPE CHILD
                Expression<Func<ItemType, bool>> expr = e => e.Type.Equals(type);
                ItemType childItemType = this.unitOfWork.ItemType.GetFirstOrDefault(expr);

                if (childItemType != null && childItemType.IdTypeParent != null)
                {
                    //ITEM TYPE HAS A PARENT
                    Expression<Func<ItemType, bool>> exprParent = e => e.Id == childItemType.IdTypeParent;
                    ItemType itemTypeParent = this.unitOfWork.ItemType.GetFirstOrDefault(exprParent);

                    //GET PARAMETER NAMED "TYPE"
                    Expression<Func<ItemParameter, bool>> exprParameter = e => e.IdItemParameter == 1;
                    param = this.unitOfWork.ItemParameters.GetFirstOrDefault(exprParameter);
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return param;
        }

        #endregion

        #region GET PARAMETERS FROM TYPE

        #endregion

        #region GET ITEM PARAMETERS
        #endregion

        #region GET ITEM PARAMETER (1 PARAMETER)
        public ItemParameter GetItemParameter(int idItemParameter)
        {
            ItemParameter itemParameter = new ItemParameter();
            try
            {
                Expression<Func<ItemParameter, bool>> expr = e => e.IdItemParameter == idItemParameter;
                itemParameter = this.unitOfWork.ItemParameters.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return itemParameter;
        }
        #endregion

        #region GET PARAMETER BY NAME
        public ItemParameter GetItemParameterByName(string parameterName)
        {
            ItemParameter itemParameter = new ItemParameter();
            try
            {
                Expression<Func<ItemParameter, bool>> expr = e => e.ItemParameterName == parameterName;
                itemParameter = this.unitOfWork.ItemParameters.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return itemParameter;
        }
        #endregion

        #region DISPOSE
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
