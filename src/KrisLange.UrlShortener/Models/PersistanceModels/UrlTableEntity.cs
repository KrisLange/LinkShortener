using System;
using Azure;
using Azure.Data.Tables;
using KrisLange.UrlShortener.Models.DomainModels;

namespace KrisLange.UrlShortener.Models
{
    public class UrlTableEntity : ITableEntity
    {
        public UrlTableEntity(string shortKey)
        {
            PartitionKey = shortKey;
            RowKey = shortKey;
        }

        public UrlTableEntity()
        {
        }

        public string RawURL { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public static UrlTableEntity Convert(UrlModel urlModel)
        {
            UrlTableEntity result = new UrlTableEntity()
                {PartitionKey = urlModel.ShortUrlId, RowKey = urlModel.ShortUrlId, RawURL = urlModel.LongUrl};

            return result;
        }
        
        public static UrlModel Convert(UrlTableEntity urlTableEntity)
        {
            UrlModel result = new UrlModel()
            {
                ShortUrlId = urlTableEntity.PartitionKey, LongUrl = urlTableEntity.RawURL,
                LastModifiedTime = urlTableEntity.Timestamp.Value.UtcDateTime
            };
            return result;
        }
    }
}