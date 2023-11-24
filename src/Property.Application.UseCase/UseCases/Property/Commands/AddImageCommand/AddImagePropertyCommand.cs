using MediatR;
using Property.Application.UseCase.Commons.Bases;

namespace Property.Application.UseCase.UseCases.Property.Commands.AddImageCommand
{
    public class AddImagePropertyCommand : IRequest<BaseResponse<bool>>
    {
        public int? IdPropertyImage { get; set; }
        public int? IdProperty { get; set; }
        public string? FilePropertyImage { get; set; }
        public bool? Enabled { get; set; }
    }
}
