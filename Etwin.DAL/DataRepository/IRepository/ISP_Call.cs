using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface ISP_Call : IDisposable
    {
        T Single<T>(string procedureName, DynamicParameters param=null);

        void Execute(string procedureName, DynamicParameters param = null);
        IDataReader ExecuteReader(string sqlQuery, DynamicParameters param = null);
        T OneRecord<T>(string procedureName, DynamicParameters param = null);

        string OneRecordJson(string procedureName, DynamicParameters param = null);

        IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null);

        Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1,T2>(string procedureName, DynamicParameters param = null);
    }
}
