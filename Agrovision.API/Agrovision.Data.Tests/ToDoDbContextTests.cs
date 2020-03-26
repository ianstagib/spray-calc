using System.Threading.Tasks;
using NUnit.Framework;

namespace Agrovision.Data.Tests
{
    public class ToDoDbContextTests : TestWithSqlite
    {
        [Test]
        public async Task DatabaseIsAvailableAndCanBeConnectedTo()
        {
            Assert.True(await DbContext.Database.CanConnectAsync());
        }
    }
}
