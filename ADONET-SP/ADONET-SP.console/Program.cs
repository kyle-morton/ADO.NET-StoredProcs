using ADONET_SP.data;
using ADONET_SP.data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_SP.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var rolesJson = new UserRepository().GetRoles();
            Console.WriteLine("ROLES: " + rolesJson);
            Console.ReadLine();


            var searchJson = JsonConvert.SerializeObject(new SearchModel
            {
                Count = 50,
                Offset = 0,
                SearchTerm = ""
            });
            var usersJson = new UserRepository().GetUsers(searchJson);
            Console.WriteLine("Users: " + usersJson);
            Console.ReadLine();
        }
    }
}
