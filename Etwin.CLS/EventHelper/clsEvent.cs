using Etwin.CLS.GenericClass;
using LogDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;


namespace Etwin.CLS.EventHelper
{
    public class clsEvent
    {
        #region VARS
        public MethodInfo method;
        public object classInstance;
        public object[] o;
        #endregion

        #region PROPERTIES
        public MethodInfo Method
        {
            get { return this.method; }
            set { this.method = value; }
        }

        public object ClassInstance
        {
            get { return this.classInstance; }
            set { this.classInstance = value; }
        }

        public object[] Parameters
        {
            get { return this.o; }
            set { this.o = value; }
        }
        #endregion

        public void RunMethod(string className, string methodName, IList<KeyValuePair<string, string>> parameters = null)
        {
            try
            {
                // Get the current assembly
                Assembly currentAssembly = Assembly.GetExecutingAssembly();

                // Get the type of the class specified by name
                Type type = currentAssembly.GetTypes().Where(x => x.Name == className).FirstOrDefault();
                //Get class type
                if (type != null)
                {
                    //Create class instance
                    this.ClassInstance = Activator.CreateInstance(type);
                    int i = 0;
                    if (parameters != null)
                    {
                        object[] o = new object[parameters.Count()];

                        //Get method
                        this.Method = type.GetMethod(methodName);

                        if (method != null)
                        {
                            foreach (KeyValuePair<string, string> param in parameters)
                            {

                                //Method's paramters analysis
                                if (parameters != null)
                                {
                                    //There are some parameters

                                    //Dictionary<object,object> dict =(Dictionary<object, object>)parameters[0];
                                    clsGenericClass cls = new clsGenericClass();

                                    o[i] = cls.GetVariableType(param.Key, param.Value);
                                    i++;
                                }
                                else
                                {
                                    //There are no parameters
                                }
                            }

                            this.Parameters = o;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
        }


    }
}
