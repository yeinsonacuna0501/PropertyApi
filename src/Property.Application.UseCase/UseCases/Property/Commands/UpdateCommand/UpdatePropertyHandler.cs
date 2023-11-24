using AutoMapper;
using MediatR;
using Property.Application.Interface.Interfaces;
using Property.Application.UseCase.Commons.Bases;
using Property.Utilities.Constants;
using Property.Utilities.HelperExtensions;
using Entity = Property.Domain.Entities;

namespace Property.Application.UseCase.UseCases.Property.Commands.UpdateCommand
{
    public class UpdatePropertyHandler : IRequestHandler<UpdatePropertyCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdatePropertyHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var property = _mapper.Map<Entity.Property>(request);
                var parameters = property.GetPropertiesWithValues();
                response.Data = await _unitOfWork.Property.ExecAsync(SP.spPropertyEdit, parameters);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_UPDATE;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message; 
            }
            return response;
        }
    }
}
