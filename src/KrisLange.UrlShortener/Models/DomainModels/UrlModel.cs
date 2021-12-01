using System;
using System.Dynamic;

namespace KrisLange.UrlShortener.Models.DomainModels
{
    public class UrlModel
    {
        public string ShortUrlId { get; set; }
        public string LongUrl { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastModifiedTime { get; set; }

        public static UrlModel Convert(UrlObject urlObj)
        {
            UrlModel result = new UrlModel() { ShortUrlId = urlObj.ShortUrlId, LongUrl = urlObj.LongUrl };

            return result;
        }
        
        
    }
}