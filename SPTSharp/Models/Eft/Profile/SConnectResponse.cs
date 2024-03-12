namespace SPTSharp.Models.Eft.Profile
{
    public struct SConnectResponse
    {
        public string backendUrl;
        public string name;
        public List<string> editions;
        public Dictionary<string, string> profileDescriptions;
    }
}
