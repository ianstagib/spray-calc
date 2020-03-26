using System;
using System.Linq;
using Agrovision.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NUnit.Framework;

namespace Agrovision.Data.Tests.ConfigurationTests
{
    public class AgentConfigurationTests : TestWithSqlite
    {
        [Test]
        public void TableShouldGetCreated()
        {
            Assert.False(EnumerableExtensions.Any(DbContext.Agents));
        }

        [Test]
        public void NameIsRequired()
        {
            var newItem = new Agent();
            DbContext.Agents.Add(newItem);

            Assert.Throws<DbUpdateException>(() => DbContext.SaveChanges());
        }

        [Test]
        public void AddedItemShouldGetGeneratedId()
        {
            var newItem = new Agent() { Name = "Testitem" };
            DbContext.Agents.Add(newItem);
            DbContext.SaveChanges();

            Assert.That(0, Is.Not.EqualTo(newItem.Id));
        }

        [Test]
        public void AddedItemShouldGetPersisted()
        {
            var newItem = new Agent() { Name = "Testitem" };
            DbContext.Agents.Add(newItem);
            DbContext.SaveChanges();

            Assert.That(newItem, Is.EqualTo(DbContext.Agents.Find(newItem.Id)));
            Assert.That(1, Is.EqualTo(Enumerable.ToList(DbContext.Agents).Count()));
        }
    }
}
