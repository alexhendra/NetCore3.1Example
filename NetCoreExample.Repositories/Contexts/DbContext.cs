using NetCoreExample.Interfaces.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NetCoreExample.Repositories.Contexts
{
    public class DbContext : IDbContext
    {
        private static IDbConnection _db;
        private static string _connString = string.Empty;
        private readonly string _providerName = "System.Data.SqlClient";

        public DbContext(string connStr)
        {
            _connString = connStr;
        }

        public IDbConnection DB
        {
            get
            {
                if (_db == null)
                {
                    _db = OpenConnection();
                }
                else
                {
                    if (_db.State == ConnectionState.Closed)
                        _db.Open();
                }
                return _db;
            }
        }

        private IDbConnection OpenConnection()
        {
            DbConnection conn;
            try
            {
                DbProviderFactories.RegisterFactory(_providerName, SqlClientFactory.Instance);
                IEnumerable<string> invariants = DbProviderFactories.GetProviderInvariantNames();
                DbProviderFactory factory = DbProviderFactories.GetFactory(invariants.FirstOrDefault());
                conn = factory.CreateConnection();
                conn.ConnectionString = _connString;
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return conn;
        }

        public void Dispose()
        {
            if (_db != null)
            {
                try
                {
                    if (_db.State != ConnectionState.Closed)
                        _db.Close();
                }
                finally
                {
                    _db.Dispose();
                }
            }
            GC.SuppressFinalize(this);
        }
    }
}
