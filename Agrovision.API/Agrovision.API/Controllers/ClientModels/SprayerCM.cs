using System;

namespace Agrovision.API.Controllers.ClientModels
{
    public class SprayerCM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RateMin { get; set; }
        public int RateMax { get; set; }
    }
}