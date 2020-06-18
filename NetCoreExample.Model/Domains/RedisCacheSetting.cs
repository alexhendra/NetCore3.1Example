using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreExample.Model.Domains
{
    public class RedisCacheSetting
    {
        public bool Enabled { get; set; }
        public string ConnectionString { get; set; }
        public string InstanceName { get; set; }
    }
}
