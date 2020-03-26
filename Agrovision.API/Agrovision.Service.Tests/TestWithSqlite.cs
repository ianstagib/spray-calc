using System;
using Agrovision.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Agrovision.Service.Test
{
    public abstract class TestWithSqlite : IDisposable
    {
        private const string ConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;

        protected readonly SprayCalcDbContext Context;

        protected TestWithSqlite()
        {
            _connection = new SqliteConnection(ConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<SprayCalcDbContext>()
                .UseSqlite(_connection)
                .Options;
            Context = new SprayCalcDbContext(options);
            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}