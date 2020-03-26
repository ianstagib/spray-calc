using System;

namespace Agrovision.Dto
{
    public class Agent : IDto<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal RecommendedDosage { get; set; }
    }
}