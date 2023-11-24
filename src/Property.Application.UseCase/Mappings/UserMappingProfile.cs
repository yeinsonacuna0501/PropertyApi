using AutoMapper;
using Property.Application.UseCase.UseCases.User.Queries.GetLoginUser;
using Property.Domain.Entities;

namespace Property.Application.UseCase.Mappings
{
    /// <summary>
    /// Perfil de mapeo para entidades relacionadas con usuarios.
    /// Configura el mapeo entre entidades y consultas de obtención de usuarios.
    /// </summary>
    public class UserMappingProfile : Profile
    {
        /// <summary>
        /// Constructor que configura el mapeo entre entidades y consultas de obtención de usuarios.
        /// </summary>
        public UserMappingProfile()
        {
            CreateMap<User, GetUserLoginQuery>().ReverseMap();
        }
        
    }
}
