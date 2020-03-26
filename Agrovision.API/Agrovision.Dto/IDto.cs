namespace Agrovision.Dto
{
    interface IDto<TPk>
    {
        TPk Id { get; set; }
    }
}