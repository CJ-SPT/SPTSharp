using SPTSharp.Controllers;
using SPTSharp.Models.Spt.Server;


namespace SPTSharp.Helpers
{
    public static class DatabaseHelpers
    {
        private static DatabaseTables _tables => Singleton<DatabaseController>.Instance.GetTables();


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
