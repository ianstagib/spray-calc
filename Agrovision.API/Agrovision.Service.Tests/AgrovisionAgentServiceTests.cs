using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agrovision.Dto;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Agrovision.Service.Test
{
    public class AgrovisionAgentServiceTests : TestWithSqlite
    {
        private static readonly Agent FirstItem = new Agent() { Id = 1, Name = "First Agent", RecommendedDosage = (decimal)1.5};
        private static readonly Agent SecondItem = new Agent() { Id = 2, Name = "Second Agent", RecommendedDosage = (decimal)2.5};
        private readonly List<Agent> _agents;

        public AgrovisionAgentServiceTests()
        {
            _agents = new List<Agent> {FirstItem, SecondItem};
            Context.Agents.AddRange(_agents);
            Context.SaveChanges();
        }

        [Test]
        public async Task GetAsyncShouldReturnCorrectAgent()
        {
            var service = new AgentService(Context);

            var actualItem = await service.GetAgentAsync(FirstItem.Id);

            Assert.AreEqual(FirstItem.Id, actualItem.Id);
        }

        [Test]
        public async Task GetAgentListAsyncShouldReturnAllAgents()
        {
            var service = new AgentService(Context);

            var agentsFromService = await service.GetAgentListAsync();
            
            Assert.That(agentsFromService.Any(p => p.Id == FirstItem.Id));
            Assert.That(agentsFromService.Any(p => p.Id == SecondItem.Id));

            Assert.AreEqual(_agents.Count(), agentsFromService.Count());
        }

        [Test]
        public async Task AddAgentAsyncShouldAddAgent()
        {
            var service = new AgentService(Context);
            var thirdItem = new Agent() {Name = "Third Item", RecommendedDosage = (decimal)1.6};

            await service.AddAgentAsync(thirdItem);

            var agentsFromService = await service.GetAgentListAsync();
            Assert.That(agentsFromService.Any(p => p.Id == thirdItem.Id));
            Assert.AreEqual(3, agentsFromService.Count());
        }

        [Test]
        public void AddAgentAsyncWithPropertyNameIsNullShouldThrowException()
        {
            var service = new AgentService(Context);
            var thirdItem = new Agent();

            Assert.ThrowsAsync<DbUpdateException>(async () => await service.AddAgentAsync(thirdItem));
        }

        [Theory]
        [TestCase("testname")]
        [TestCase("TESTNAME")]
        [TestCase("One.Test")]
        [TestCase("$%)/)(&")]
        public async Task UpdateAgentAsyncShouldChangeName(string expectedName)
        {
            var service = new AgentService(Context);
            var itemToUpdate = await service.GetAgentAsync(FirstItem.Id);
            itemToUpdate.Name = expectedName;

            await service.UpdateAgentAsync(FirstItem);

            var updatedItem = await service.GetAgentAsync(FirstItem.Id);
            Assert.AreEqual(expectedName, updatedItem.Name);
        }

        [Test]
        public async Task UpdateAgentAsyncWithPropertyNameIsNullShouldThrowException()
        {
            var service = new AgentService(Context);
            var itemToUpdate = await service.GetAgentAsync(FirstItem.Id);

            itemToUpdate.Name = null;

            Assert.ThrowsAsync<DbUpdateException>(() => service.UpdateAgentAsync(itemToUpdate));
        }

        [Test]
        public async Task DeleteAgentAsyncShouldDeleteAgent()
        {
            var service = new AgentService(Context);

            await service.DeleteAgentAsync(FirstItem.Id);

            var agentsFromService = await service.GetAgentListAsync();
            Assert.That(agentsFromService.All(p => p.Id != FirstItem.Id));
        }
    }
}