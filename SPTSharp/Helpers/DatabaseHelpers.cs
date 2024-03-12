using SPTSharp.Controllers;
using SPTSharp.Models.Eft.Common.Tables;
using SPTSharp.Models.Spt.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTSharp.Helpers
{
    public static class DatabaseHelpers
    {
        private static DatabaseTables _tables => Singleton<DatabaseController>.Instance.Tables;


        // Build a List containing ProfileSides
        public static List<string> GetProfileEditions()
        {
            return new List<string>
            {
                "Standard",
                "Left Behind",
                "Prepare To Escape",
                "Edge Of Darkness",
                "SPT Developer",
                "SPT Easy start",
                "SPT Zero to hero"
            };
        }
    }
}
