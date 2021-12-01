using System;
using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using KrisLange.UrlShortener.Models;
using KrisLange.UrlShortener.Models.DomainModels;
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

        public UrlModel Get(string key)
        {
            var tmp = _table.GetEntity<UrlTableEntity>(key, key);

            var result = UrlTableEntity.Convert(tmp.Value);
            return result;
        }

        public void Put(UrlModel url)
        {
            var urlTableEntity = UrlTableEntity.Convert(url);

            _table.AddEntity<UrlTableEntity>(urlTableEntity);
        }
    }
}