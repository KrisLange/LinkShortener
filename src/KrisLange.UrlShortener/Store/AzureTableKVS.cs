using System;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using KrisLange.UrlShortener.Models;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace KrisLange.UrlShortener.Store
{
    public class AzureTableKVS : IKeyValueStore
    {
        private TableClient _table;
        public AzureTableKVS(IOptions<AzureStorageConfig> asc)
        {
            TableServiceClient tsc = new TableServiceClient(asc.Value.ConnectionString);
            tsc.CreateTableIfNotExists(asc.Value.TableName);
            
            _table = new TableClient(asc.Value.ConnectionString, asc.Value.TableName);
        }

        public string Get(string key)
        {
            var tmp = _table.GetEntity<UrlTableEntity>(key, key);

            return tmp.Value.Raw_URL;
        }

        public void Put(string key, string value)
        {
            var urlRecord = new UrlTableEntity(key);
            urlRecord.Raw_URL = value;

            _table.AddEntity<UrlTableEntity>(urlRecord);
        }
    }
}