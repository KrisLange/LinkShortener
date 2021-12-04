using System;

namespace KrisLange.UrlShortener.Models
{
    public class LinkStorageConfig
    {
        public enum StorageType
        {
            InMemory,
            AzureTable
        }

        public StorageType UnderlyingStorageType { get; set; }
    }
}