using AutoMapper;
using Property.Application.Dtos.Owner.Response;
using Property.Application.UseCase.UseCases.Owner.Commands.CreateCommand;
using Property.Application.UseCase.UseCases.Owner.Commands.UpdateCommand;
using Property.Domain.Entities;

namespace Property.Application.UseCase.Mappings
{
    /// <summary>
    /// Perfil de mapeo para entidades relacionadas con propietarios.
    /// Configura los mapeos entre entidades y DTOs de propietarios.
    /// </summary>
    public class OwnerMappingProfile : Profile
    {
        /// <summary>
        /// Constructor que configura los mapeos entre entidades y DTOs de propietarios.
        /// </summary>
        public OwnerMappingProfile()
        {
            CreateMap<Owner,GetAllOwnerResponseDto>().ReverseMap();

            CreateMap<Owner,GetOwnerByIdResponseDto>().ReverseMap();

            CreateMap<CreateOwnerCommand, Owner>();

            CreateMap<UpdateOwnerCommand, Owner>();

        }
    }
}
