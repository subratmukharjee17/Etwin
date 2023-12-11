using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Etwin.DAL.DataRepository.IRepository
{
    public interface IQUERY_Call : IDisposable
    {
        T Single<T>(string sqlQuery, DynamicParameters param=null);

        void Execute(string sqlQuery, DynamicParameters param = null);

        T OneRecord<T>(string sqlQuery, DynamicParameters param = null);

        IEnumerable<T> List<T>(string sqlQuery, DynamicParameters param = null);

        Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1,T2>(string sqlQuery, DynamicParameters param = null);
    }
}
