using LogDll;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;


namespace ETwin.Helper.Utilities
{
    public static class clsDynamicClass
    {
        /// <summary>
        /// AGGIUNGE LE PROPRIETA' ALL'OGGETTO DINAMICO expando
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expando"></param>
        /// <param name="obj"></param>
        public static void AddProperties<T>(ExpandoObject expando, T obj)
        {
            ////clsLog.Info(">>> ADDPROPERTIES - INIZIO");
            try
            {
                foreach (PropertyInfo pi in obj.GetType().GetProperties())
                {
                    AddProperty(expando, pi.Name, pi.GetValue(obj, null));
                }
            }
            catch (Exception ex)
            {
                clsLog.Error("AddProperties - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> ADDPROPERTIES - FINE");
            }
        }

        /// <summary>
        /// AGGIUNGE 1 PROPRIETA' ALL'OGGETTO DINAMICO expando
        /// </summary>
        /// <param name="expando"></param>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        public static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            ////clsLog.Info(">>> ADDPROPERTY - INIZIO");
            try
            {
                var expandoDict = expando as IDictionary<string, object>;
                if (expandoDict.ContainsKey(propertyName))
                {
                    expandoDict[propertyName] = propertyValue;
                }
                else
                {
                    expandoDict.Add(propertyName, propertyValue);
                }
            }
            catch (Exception ex)
            {
                clsLog.Error("AddProperty - Error: " + ex.ToString());
            }
            finally
            {
                ////clsLog.Info(">>> ADDPROPERTY - FINE");
            }
        }

        /// <summary>
        /// CONVERTE L'OGGETTO GENERICO T IN OGGETTO DINAMICO. NB: VA CONTROLLATA!!!!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T ConvertDynamic<T>(dynamic data)
        {
            //clsLog.Info(">>> CONVERTDYNAMIC - INIZIO");
            T result = default;

            try
            {
                result = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(data), new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            catch (Exception ex)
            {
                clsLog.Error("ConvertDynamic - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> CONVERTDYNAMIC - FINE");
            }

            return result;
        }


        /// <summary>
        /// RITORNA TUTTE LE PROPRIETA' DELLA CLASSE GENERICA T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<PropertyInfo> GetModelProperties<T>()
        {
            //clsLog.Info(">>> GETMODELPROPERTIES - INIZIO");
            IList<PropertyInfo> result = new List<PropertyInfo>();

            try
            {
                Type t = typeof(T);
                result = t.GetProperties();
            }
            catch (Exception ex)
            {
                result = default;
                clsLog.Error("GetModelProperties - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETMODELPROPERTIES - FINE");
            }

            return result;
        }


        /// <summary>
        /// RITORNA IL VALORE DI UNA PROPRIETA'
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static object GetModelPropertyValue<T>(T model, string property)
        {
            //clsLog.Info(">>> GETMODELPROPERTYVALUE - INIZIO");
            //clsLog.Info("Proprieta': " + property);

            object? result = null;

            try
            {
                IDictionary<string, object>? keyValuePairs = model as IDictionary<string, object>;
                if (keyValuePairs != null)
                {
                    result = keyValuePairs[property];
                }
                if (result != null)
                {
                    //clsLog.Info("Valore: " + result.ToString());
                }
                else
                {
                    //clsLog.Info("Proprietà non trovata.");
                }

                //PropertyInfo pi = model.GetType().GetProperty(property);
                //if(pi!=null)
                //{
                //    result = pi.GetValue(model, null);
                //    //clsLog.Info("Valore: " + result.ToString());
                //}
                //else
                //{
                //    //clsLog.Info("Proprietà non trovata.");
                //}
            }
            catch (Exception ex)
            {
                result = null;
                clsLog.Error("GetModelPropertyValue - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> GETMODELPROPERTYVALUE - FINE");
            }

            return result;
        }

        public static void SetModelPropertyValue<T>(T model, string property, object value)
        {
            //clsLog.Info(">>> SETMODELPROPERTYVALUE - INIZIO");
            //clsLog.Info("Proprieta': " + property);
            //clsLog.Info("Valore: " + value.ToString());

            try
            {
                PropertyInfo pi = model.GetType().GetProperty(property);
                if (pi != null)
                {
                    pi.SetValue(model, value);
                }
                else
                {
                    //clsLog.Info("Proprietà non trovata.");
                }
            }
            catch (Exception ex)
            {
                clsLog.Error("SetModelPropertyValue - Error: " + ex.ToString());
            }
            finally
            {
                //clsLog.Info(">>> SETMODELPROPERTYVALUE - FINE");
            }
        }

    }
}
