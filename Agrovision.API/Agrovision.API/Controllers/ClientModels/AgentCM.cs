using System;

namespace Agrovision.API.Controllers.ClientModels
{
    public class AgentCM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal RecommendedDosage { get; set; }
    }
}