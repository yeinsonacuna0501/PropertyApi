using MediatR;
using Microsoft.AspNetCore.Http;
using Property.Application.UseCase.Commons.Bases;

namespace Property.Application.UseCase.UseCases.Property.Commands.AddImageCommand
{
    public class UploadImagePropertyCommand 
    {
        public int? IdProperty { get; set; }
        public IFormFile? FilePropertyImage { get; set; }
        public bool? Enabled { get; set; }
    }
}
