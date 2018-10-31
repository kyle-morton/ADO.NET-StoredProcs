using ADONET_SP.data.Extensions;
using System.Collections.Generic;

namespace ADONET_SP.data
{
    public class UserRepository : RepositoryBase
    {
        public string GetRoles()
        {
            var parameters = new Dictionary<string, object> { { "IsJSON", 1 } }.ToSqlParameters();

            return CallStoredProcedure("master.spGetRoles", parameters);
        }

        public string GetUsers(string json)
        {
            var parameters = new Dictionary<string, object>
            {
                { "IsJSON", 1 },
                { "OffSet", null },
                { "Count", null },
                { "SearchTerm", null },
                { "json", json }
            }.ToSqlParameters();

            return CallStoredProcedure("master.spGetUsers", parameters);
        }
    }
}
