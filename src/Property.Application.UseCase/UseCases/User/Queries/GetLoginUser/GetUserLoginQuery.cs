using MediatR;
using Property.Application.Dtos.User.Response;
using Property.Application.UseCase.Commons.Bases;

namespace Property.Application.UseCase.UseCases.User.Queries.GetLoginUser
{
    public class GetUserLoginQuery : IRequest<BaseResponse<UserLoginResponseDto>>
    {
        public string? Name { get; set; }

        public string? Password { get; set; }
    }
}
