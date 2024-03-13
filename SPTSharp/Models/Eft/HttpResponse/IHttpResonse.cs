
namespace SPTSharp.Models.Eft.HttpResponse
{
    public class GetBodyResponseData<T>
    {
        public int err { get; set; }
        public object errmsg { get; set; }
        public T data { get; set; }
    }

    public class NullResponseData
    {
        int err { get; set; }
        public object errmsg { get; set; }
        public object? data { get; set; } = null;
    }
}
