namespace Agrovision.Dto
{
    public class Sprayer: IDto<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal RateMin { get; set; }
        public decimal RateMax { get; set; }
    }
}