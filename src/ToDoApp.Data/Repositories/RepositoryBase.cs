using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ToDoApp.Data.Repositories
{
    internal class RepositoryBase
    {
        private const string CONNECTIONSTRING_KEY = "ConnectionString";

        protected SqlConnection connection;


        public RepositoryBase(IConfigurationRoot configuration)
        {
            string connectionString = configuration[CONNECTIONSTRING_KEY];
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("Connection string not found.");

            connection = new SqlConnection(connectionString);

        }

    }
}
