using System;
using System.Collections.Generic;
using System.Linq;
using Etwin.DAL.DataRepository;
using Etwin.DAL.DataRepository.IRepository;
using Etwin.Model;
using System.ComponentModel;
using System.Linq.Expressions;
using LogDll;
using System.Reflection;
using ETwin.Helper.Utilities;
using Etwin.Model.Context;

namespace Etwin.BAL.BusinnessLogic
{
    public class BlOperators : IDisposable
    {
        IUnitOfWork unitOfWork = null;
        private readonly ETwinContext _db;

        public BlOperators(string cs = null)
        {
            this._db = new ETwinContext(cs);
            this.unitOfWork = new UnitOfWork(_db);
        }

        
        public Operator GetOperator(string username, string password)
        {
            //clsLog.Info(">>> GETOPERATORE - INIZIO");

            Operator operatore = new Operator();
            try
            {
                Expression<Func<Operator, bool>> expr = e => e.Username == username && e.Password == password;

                operatore = this.unitOfWork.Operators.GetFirstOrDefault(expr);
            }
            catch (Exception ex)
            {
                operatore = null;
                clsLog.Error("GETOPERATORE - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETOPERATORE - FINE");
            }

            return operatore;   
        }

        public Operator GetOperatorFromCode(string matricola)
        {
            //clsLog.Info(">>> GETOPERATORE - INIZIO");

            Operator operatore = new Operator();
            try
            {
                Expression<Func<Operator, bool>> expr = e => e.OperatorCode == matricola;

                operatore = this.unitOfWork.Operators.GetFirstOrDefault(expr, ""/*"IdOperatorRoleNavigation,IdOperatorStateNavigation"*/);
            }
            catch (Exception ex)
            {
                operatore = null;
                clsLog.Error("GETOPERATORE - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETOPERATORE - FINE");
            }

            return operatore;
        }

        public IList<Operator> GetAllOperator()
        {
            //clsLog.Info(">>> GETOPERATOR - INIZIO");

            IList<Operator> lstOperator = new List<Operator>();

            try
            {
                lstOperator = this.unitOfWork.Operators.GetAll(null, null, "IdDepartmentNavigation,IdOperatorRoleNavigation,IdOperatorStateNavigation").ToList();
            }
            catch (Exception ex)
            {
                clsLog.Error("GETALLOPERATOR - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETOPERATOR - FINE");
            }

            return lstOperator;
        }


        public BindingList<Operator> GetAllOperatorsTimbratore(int idAmbito)
        {
            //clsLog.Info(">>> GETALLOPERATORSTIMBRATORE - INIZIO");
            IList<Operator> lstOperators = new List<Operator>();
            BindingList<Operator> bindingOperators = new BindingList<Operator>();
            try
            {
                Expression<Func<Operator, bool>> expr = e => e.IdDepartment == idAmbito;
                lstOperators = this.unitOfWork.Operators.GetAll(expr, null, "IdOperatorRoleNavigation,IdOperatorStateNavigation").ToList();

                bindingOperators = new BindingList<Operator>(lstOperators);
                //clsLog.Info(">>> Operatori trovati: " + bindingOperators.Count());
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETALLOPERATORSTIMBRATORE - FINE");
            }
            return bindingOperators;
        }

        public void UpdateOperatore(Operator operatore)
        {
            //clsLog.Info(">>> UpdateOperator - INIZIO");

            try
            {
                this.unitOfWork.Operators.Update(operatore);
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }

        }

        /// <summary>
        /// UPDATE Operator
        /// </summary>
        /// <param name="Operator"></param>
        public void UpdateOperator(dynamic Operator)
        {
            //clsLog.Info(">>> UpdateOperator - INIZIO");

            try
            {
                // OGGETTO OPERATOR DA AGGIORNARE
                Operator operatorToUpdate = new Operator();

                // LISTA PROPRIETA' MODELLO OPERATOR
                IList<PropertyInfo> modInfo = clsDynamicClass.GetModelProperties<Operator>();
                foreach (PropertyInfo pi in modInfo)
                {
                    // RICAVO IL VALORE DELLA PROPRIETA' pi DALL'OGGETTO DINAMICO OPERATOR 
                    object objValore = clsDynamicClass.GetModelPropertyValue<dynamic>(Operator, pi.Name);
                    if (objValore != null)
                    {
                        // SE LO TROVO LO SETTO SULL'OGGETTO operatorToUpdate 
                        clsDynamicClass.SetModelPropertyValue<Operator> (operatorToUpdate, pi.Name, objValore);
                    }
                }

                // AGGIORNAMENTO A DB
                this.unitOfWork.Operators.Update(operatorToUpdate);
            }
            catch (Exception ex)
            {
                clsLog.Error("UpdateOperator - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> UpdateOperator - FINE");
            }
        }

        public void Dispose()
        {
            //this.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
