using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NetCoreExample.Interfaces.Contexts
{
    public interface IDbContext : IDisposable
    {
        IDbConnection DB { get; }
    }
}
