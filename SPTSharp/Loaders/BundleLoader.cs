namespace SPTSharp.Loaders
{
    public class BundleInfo
    {
        public BundleInfo(string modPath, string key, string path, string filePath, string dependencyKeys)
        {
            this.modPath = modPath;
            this.key = key;
            this.path = path;
            this.filePath = filePath;
            this.dependencyKeys = dependencyKeys;
        }

        public string modPath { get; set; }
        public string key { get; set; }
        public string path { get; set; }
        public string filePath { get; set; }
        public string dependencyKeys { get; set; }

    }

    public class BundleLoader
    {
        public Dictionary<string, BundleInfo> bundles = new Dictionary<string, BundleInfo>();

        public List<BundleInfo> GetBundles(bool local)
        {
            var result = new List<BundleInfo>();

            foreach (var bundle in bundles)
            {
                result.Add(GetBundle(bundle.Key, local));
            }

            return result;
        }

        // TODO
        public BundleInfo GetBundle(string key, bool local)
        {
            return new BundleInfo("", "", "", "", "");
        }
    }
}
