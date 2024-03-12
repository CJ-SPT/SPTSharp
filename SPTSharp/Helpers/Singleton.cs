using System.Collections.Generic;

namespace SPTSharp.Helpers
{
    public class Singleton<T> where T : class, new()
    {
        private static readonly Dictionary<Type, T> instances = new Dictionary<Type, T>();
        private static readonly object lockObject = new object();

        private Singleton() { }

        // Get or Set an instance of an object
        public static T Instance
        {
            get
            {
                Type type = typeof(T);

                lock (lockObject)
                {
                    if (!instances.ContainsKey(type))
                    {
                        instances[type] = new T();
                    }
                }

                return instances[type];
            }
            set
            {
                Type type = typeof(T);

                lock (lockObject)
                {
                    instances[type] = value;
                }
            }
        }

        // Returns if the object is instantiated
        public static bool Instantiated
        {
            get
            {
                Type type = typeof(T);
                return instances.ContainsKey(type);
            }
        }
    }
}
