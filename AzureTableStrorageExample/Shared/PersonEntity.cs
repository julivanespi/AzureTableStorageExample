using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTableStrorageExample.Shared
{
    public class PersonEntity : TableEntity
    {
        public PersonEntity() { }

        public PersonEntity(string lastName, string firstName)
        {
            PartitionKey = lastName;
            RowKey = firstName;
        }

        public string Email { get; set; }
        public string Age { get; set; }
        public string NickName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
