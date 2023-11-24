using MediatR;
using Property.Application.Dtos.Property.Response;
using Property.Application.UseCase.Commons.Bases;

namespace Property.Application.UseCase.UseCases.Property.Queries.GetFilterQuery
{
    public class GetPropertyFilterQuery : IRequest<BaseResponse<IEnumerable<GetListPropertyResponseDto>>>
    {
        public string? Filter { get; set; }
    }
}
