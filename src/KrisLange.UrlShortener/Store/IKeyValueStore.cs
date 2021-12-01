using KrisLange.UrlShortener.Models.DomainModels;

namespace KrisLange.UrlShortener.Store
{
    public interface IKeyValueStore
    {
        public UrlModel Get(string key);
        public void Put(UrlModel url);
    }
}