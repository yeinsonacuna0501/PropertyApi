using MediatR;
using Property.Application.Dtos.Owner.Response;
using Property.Application.UseCase.Commons.Bases;

namespace Property.Application.UseCase.UseCases.Owner.Queries.GetByIdQuery
{
    public class GetOwnerByIdQuery : IRequest<BaseResponse<GetOwnerByIdResponseDto>>
    {
        public int IdOwner { get; set; }
    }
}
