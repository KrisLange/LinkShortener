using System.Collections.Generic;
using KrisLange.UrlShortener.Models;
using KrisLange.UrlShortener.Models.DomainModels;

namespace KrisLange.UrlShortener.Store
{
    public class InMemoryKvs: IKeyValueStore
    {
        private readonly Dictionary<string, UrlDictionaryEntity> _map;
        
        public InMemoryKvs()
        {
            _map = new Dictionary<string, UrlDictionaryEntity>();
        }

        public UrlModel Get(string key)
        {
            UrlDictionaryEntity tmp;

            if (!_map.TryGetValue(key, out tmp))
            {
                return null;
            }

            UrlModel result = UrlDictionaryEntity.Convert(tmp);
            return result;
        }

        public void Put(UrlModel urlModel)
        {
            UrlDictionaryEntity value = UrlDictionaryEntity.Convert(urlModel);
            _map[value.ShortUrlId] = value;
        }
    }
}