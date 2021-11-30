using System.Collections.Generic;

namespace KrisLange.UrlShortener.Store
{
    public class InMemoryKvs: IKeyValueStore
    {
        private readonly Dictionary<string, string> _map;
        
        public InMemoryKvs()
        {
            _map = new Dictionary<string, string>();
        }

        public string Get(string key)
        {
            string value = "";

            if (!_map.TryGetValue(key, out value))
            {
                return null;
            }

            return value;
        }

        public void Put(string key, string value)
        {
            _map[key] = value;
        }
    }
}