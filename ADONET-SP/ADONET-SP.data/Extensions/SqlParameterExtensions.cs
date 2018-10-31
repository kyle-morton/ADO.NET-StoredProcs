using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ADONET_SP.data.Extensions
{
    public static class SqlParameterExtensions
    {
        public static List<SqlParameter> ToSqlParameters(this Dictionary<string, object> dictionary)
        {
            var parameters = new List<SqlParameter>();
            dictionary.Keys.ToList().ForEach(k => {
                parameters.Add(new SqlParameter("@" + k, dictionary[k]));
            });
            return parameters;
        }
    }
}
