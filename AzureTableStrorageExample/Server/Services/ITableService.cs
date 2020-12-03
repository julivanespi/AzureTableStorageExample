using AzureTableStrorageExample.Server.Options;
using AzureTableStrorageExample.Shared;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureTableStrorageExample.Server.Services
{
    public interface ITableService
    {
        Task AddPersonAsync(PersonEntity person);
        Task<List<PersonEntity>> GetPeopleAsync();
    }

    public class TableService : ITableService
    {
        private readonly AzureTableStorageOptions _options;

        public TableService(AzureTableStorageOptions options)
        {
            _options = options;
        }


        public async Task AddPersonAsync(PersonEntity person)
        {
            TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(person);

            TableResult result = await GetTable().ExecuteAsync(insertOrMergeOperation);

            PersonEntity insertedPerson = result.Result as PersonEntity;

            Console.WriteLine("Added person to people table");
        }

        public async Task<List<PersonEntity>> GetPeopleAsync()
        {
            TableContinuationToken token = null;

            var entities = new List<PersonEntity>();
            do
            {
                var queryResult = await GetTable().ExecuteQuerySegmentedAsync(new TableQuery<PersonEntity>(), token);
                entities.AddRange(queryResult.Results);
                token = queryResult.ContinuationToken;
            } while (token != null);

            return entities;
        }

        private CloudTable GetTable()
        {
            CloudStorageAccount storageAccount;
            storageAccount = CloudStorageAccount.Parse(_options.ConnectionString);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            CloudTable table = tableClient.GetTableReference(_options.TableName);
            return table;
        }
    }
}
