using MediatR;
using Microsoft.AspNetCore.Http;
using Property.Application.UseCase.Commons.Bases;

namespace Property.Application.UseCase.UseCases.Owner.Commands.UpdateCommand
{
    public class UpdateOwnerPhotoCommand : IRequest<BaseResponse<bool>>
    {
        public int IdOwner { get; set; }
        public string? Name { get; set; }

        public string? Address { get; set; }

        public IFormFile? Photo { get; set; }

        public DateTime Birthday { get; set; }
    }
}
