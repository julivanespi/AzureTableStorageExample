﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureTableStrorageExample.Server.Options
{
    public class AzureTableStorageOptions
    {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }
    }
}
