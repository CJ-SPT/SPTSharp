#pragma warning disable
using System.Text;

namespace SPTSharp.Models.Eft.Common.Tables
{
    public class CustomizationItem
    {
        public string _id {  get; set; }
        public string _name { get; set; }
        public string _parent { get; set; }
        public string _type { get; set; }
        public CustomizationProps _props { get; set; }
        public string _proto { get; set; }
    }

    public class CustomizationProps
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public List<string> Side {  get; set; }
        public string BodyPart { get; set; }
        public bool? AvailableAsDefault { get; set; }
        public string Body {  get; set; }
        public string Hands { get; set; }
        public string Feet { get; set; }

        // string or prefab object
        public dynamic Prefab { get; set; }
        public Prefab WatchPrefab { get; set; }
        public bool IntegratedArmorVest { get; set; }
        public Xyz WatchPosition { get; set; }
        public Xyz WatchRotation { get;set; }
    }
}
