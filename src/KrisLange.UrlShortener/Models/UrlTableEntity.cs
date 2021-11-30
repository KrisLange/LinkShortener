using System;
using Azure;
using Azure.Data.Tables;

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

        public string Raw_URL { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}