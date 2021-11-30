namespace KrisLange.UrlShortener.Store
{
    public interface IKeyValueStore
    {
        public string Get(string key);
        public void Put(string key, string value);
    }
}