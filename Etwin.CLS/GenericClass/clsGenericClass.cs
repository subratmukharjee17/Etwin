using Etwin.Model.Context;
using ETwin.DAL.Models;
using LogDll;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Etwin.CLS.GenericClass
{
    public class clsGenericClass
    {
        private readonly ETwinContext _db;

        public clsGenericClass(string cs=null)
        {
            _db = new ETwinContext(cs);
        }

        public object GetVariableType(string key, string value)
        {
            object o = null;
            try
            {
                switch (key)
                {
                    case "int":
                        o = int.Parse(value);
                        break;
                    case "float":
                        break;
                    case "double":
                        break;
                    case "string":
                        o = value;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return o;
        }

        public string GetConnectionString()
        {
            string cs = "";
            try
            {
                string jsonPath = "appsettings.json";
                string jsonString = File.ReadAllText(jsonPath);
                // Deserialize the JSON in the ConnectionStrings class
                JObject jsonObj = JObject.Parse(jsonString);
                cs = ((JValue)jsonObj["ConnectionStrings"]["CsCust"]).Value.ToString();

            }
            catch (Exception ex)
            {
                clsLog.Error(ex.ToString());
            }
            return cs;
        }
    }
}
