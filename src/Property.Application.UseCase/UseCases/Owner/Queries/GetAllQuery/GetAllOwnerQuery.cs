using MediatR;
using Property.Application.Dtos.Owner.Response;
using Property.Application.UseCase.Commons.Bases;

namespace Property.Application.UseCase.UseCases.Owner.Queries.GetAllQuery
{
    public class GetAllOwnerQuery : IRequest<BaseResponse<IEnumerable<GetAllOwnerResponseDto>>>
    {
    }
}
