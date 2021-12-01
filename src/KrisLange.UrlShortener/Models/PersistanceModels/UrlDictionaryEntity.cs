using System;
using KrisLange.UrlShortener.Models.DomainModels;

namespace KrisLange.UrlShortener.Models
{
    public class UrlDictionaryEntity
    {
        public string ShortUrlId { get; set; }
        public string LongUrl { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastModifiedTime { get; set; }

        public static UrlDictionaryEntity Convert(UrlModel urlObj)
        {
            UrlDictionaryEntity result = new UrlDictionaryEntity() { ShortUrlId = urlObj.ShortUrlId, LongUrl = urlObj.LongUrl, CreationTime = urlObj.CreationTime, LastModifiedTime = urlObj.LastModifiedTime };

            return result;
        }
        
        public static UrlModel Convert(UrlDictionaryEntity urlDictEntity)
        {
            UrlModel result = new UrlModel() { ShortUrlId = urlDictEntity.ShortUrlId, LongUrl = urlDictEntity.LongUrl, CreationTime = urlDictEntity.CreationTime, LastModifiedTime = urlDictEntity.LastModifiedTime};

            return result;
        }
    }
}