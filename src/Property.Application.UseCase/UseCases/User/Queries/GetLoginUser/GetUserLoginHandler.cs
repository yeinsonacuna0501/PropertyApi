using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Property.Application.Dtos.Owner.Response;
using Property.Application.Dtos.User.Response;
using Property.Application.Interface.Interfaces;
using Property.Application.UseCase.Commons.Bases;
using Property.Utilities.Constants;
using Property.Utilities.HelperExtensions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entity = Property.Domain.Entities;

namespace Property.Application.UseCase.UseCases.User.Queries.GetLoginUser
{
    public class GetUserLoginHandler : IRequestHandler<GetUserLoginQuery, BaseResponse<UserLoginResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private string claveSecreta;

        public GetUserLoginHandler(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            claveSecreta = config.GetValue<string>("ApiSettings:Secreta");
        }

        public async Task<BaseResponse<UserLoginResponseDto>> Handle(GetUserLoginQuery request, CancellationToken cancellationToken)
        {
            var passwordEncriptado = GetPasswordMD5.obtenermd5(request.Password);

            var property = _mapper.Map<Entity.User>(request);
            property.Password = passwordEncriptado;
            var parameters = property.GetPropertiesWithValues();
            var response = new BaseResponse<UserLoginResponseDto>();
            try
            {
                var user = await _unitOfWork.User.Login(SP.spLogin, parameters);

                if (user is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                    return response;
                }
                // Aqui existe el usuario entonces procedemos a procesar el login
                var manejadorToken = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(claveSecreta);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, request.Name.ToString()),
                    new Claim(ClaimTypes.Role,user.Role),
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = manejadorToken.CreateToken(tokenDescriptor);
                user.Token = manejadorToken.WriteToken(token);
                response.IsSuccess = true;
                response.Data = _mapper.Map<UserLoginResponseDto>(user);
                response.Message = GlobalMessages.MESSAGE_QUERY;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
