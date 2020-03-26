using System;

namespace Agrovision.Dto
{
    public class Field: IDto<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Size { get; set; }
    }
}