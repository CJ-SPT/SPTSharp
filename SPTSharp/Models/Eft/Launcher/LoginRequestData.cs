#pragma warning disable
namespace SPTSharp.Models.Eft.Launcher
{
    public class LoginRequestData
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public class LoginRegisterData : LoginRequestData
    {
        public string edition { get; set; }
    }
}
