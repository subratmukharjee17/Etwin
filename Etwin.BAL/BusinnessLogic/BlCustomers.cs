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


namespace Etwin.BAL.BusinnessLogic
{
    public class BlCustomers : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlCustomers(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }


        public BindingList<Customer> GetCustomer(int idCustomer)
        {
            IList<Customer> lstCustomer = new List<Customer>();
            BindingList<Customer> bindingListCustomer = new BindingList<Customer>();
            try
            {
                Expression<Func<Customer, bool>> expr = e => e.IdCustomer == idCustomer;

                lstCustomer = this.unitOfWork.Customers.GetAll(expr).ToList();
                bindingListCustomer = new BindingList<Customer>(lstCustomer);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return bindingListCustomer;
        }

        public IList<Customer> GetTopTenCustomer()
        {
            IList<Customer> lstCustomer = new List<Customer>();
            try
            {
                lstCustomer = this.unitOfWork.Customers.GetAll().ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return lstCustomer;
        }

        public int GetIdCustomerByName(string name)
        {
            Customer customer = new Customer();
            try
            {
                Expression<Func<Customer, bool>> expr = e => e.BusinessName == name;

                customer = this.unitOfWork.Customers.GetFirstOrDefault(expr);

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return customer.IdCustomer;
        }

        public Customer GetCustomerByID(int id)
        {
            Customer customer = new Customer();
            try
            {
                Expression<Func<Customer, bool>> expr = e => e.IdCustomer == id;

                customer = this.unitOfWork.Customers.GetFirstOrDefault(expr);

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

            return customer;
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
