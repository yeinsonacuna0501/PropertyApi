using AutoMapper;
using MediatR;
using Property.Application.Interface.Interfaces;
using Property.Application.UseCase.Commons.Bases;
using Property.Domain.Entities;
using Property.Utilities.Constants;
using Property.Utilities.HelperExtensions;
using Entity = Property.Domain.Entities;

namespace Property.Application.UseCase.UseCases.Property.Commands.ChangePriceCommand
{
    public class ChangePricePropertyHandler : IRequestHandler<ChangePricePropertyCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangePricePropertyHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(ChangePricePropertyCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var property = _mapper.Map<Entity.Property>(request);
                var parameters = property.GetPropertiesWithValues();
                response.Data = await _unitOfWork.Property.ExecAsync(SP.spPropertyChangePrice, parameters);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_UPDATE_PRICE;
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
