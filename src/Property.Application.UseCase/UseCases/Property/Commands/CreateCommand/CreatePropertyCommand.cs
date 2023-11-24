using MediatR;
using Property.Application.UseCase.Commons.Bases;

namespace Property.Application.UseCase.UseCases.Property.Commands.CreateCommand
{
    public class CreatePropertyCommand : IRequest <BaseResponse<bool>>
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public decimal? Price { get; set; }
        public string? CodeInternal { get; set; }
        public int? YearProperty { get; set; }
        public int? IdOwner { get; set; }
    }
}
