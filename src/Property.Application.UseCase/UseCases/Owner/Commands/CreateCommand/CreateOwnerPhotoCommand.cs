using MediatR;
using Microsoft.AspNetCore.Http;
using Property.Application.UseCase.Commons.Bases;

namespace Property.Application.UseCase.UseCases.Owner.Commands.CreateCommand
{
    public class CreateOwnerPhotoCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public IFormFile? Photo { get; set; }

        public DateTime Birthday { get; set; }
    }
}
