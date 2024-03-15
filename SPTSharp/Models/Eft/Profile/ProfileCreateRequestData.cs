#pragma warning disable
namespace SPTSharp.Models.Eft.Profile
{
    public class ProfileCreateRequestData
    {
        public string side {  get; set; }
        public string nickname {  get; set; }
        public string headId { get; set; }
        public string voiceId { get; set; }
    }

    public class CreateProfileResponseData
    {
        public string uid { get; set; }
    }
}
