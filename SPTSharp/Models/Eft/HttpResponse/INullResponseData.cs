namespace SPTSharp.Models.Eft.HttpResponse
{
    public interface INullResponseData
    {
        public int err { get; set; }
        public object errmsg { get; set; }

        public object data { get; set; }
    }
}
