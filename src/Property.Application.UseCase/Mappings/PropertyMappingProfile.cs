using AutoMapper;
using Property.Application.Dtos.Property.Response;
using Property.Application.UseCase.UseCases.Property.Commands.AddImageCommand;
using Property.Application.UseCase.UseCases.Property.Commands.ChangePriceCommand;
using Property.Application.UseCase.UseCases.Property.Commands.CreateCommand;
using Property.Application.UseCase.UseCases.Property.Commands.UpdateCommand;
using Property.Domain.Entities;
using Entity = Property.Domain.Entities;

namespace Property.Application.UseCase.Mappings
{
    /// <summary>
    /// Perfil de mapeo para entidades relacionadas con propietarios.
    /// Configura los mapeos entre entidades y DTOs de propietarios.
    /// </summary>
    public class PropertyMappingProfile : Profile
    {
        /// <summary>
        /// Constructor que configura los mapeos entre entidades y DTOs de propietarios.
        /// </summary>
        public PropertyMappingProfile() { 
        
            CreateMap<CreatePropertyCommand,Entity.Property>();
            CreateMap<UpdatePropertyCommand, Entity.Property>();
            CreateMap<ChangePricePropertyCommand, Entity.Property>();
            CreateMap<Entity.Property, GetListPropertyResponseDto>().ReverseMap();
            CreateMap<AddImagePropertyCommand, PropertyImage>();
            CreateMap<PropertyImage, GetImagesPropertyResponseDto>().ReverseMap();
            CreateMap<PropertyTrace, GetTracesPropertyResponseDto>().ReverseMap();
        }
    }
}
