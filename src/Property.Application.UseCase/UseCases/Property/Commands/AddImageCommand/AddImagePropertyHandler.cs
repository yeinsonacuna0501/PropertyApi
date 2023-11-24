using AutoMapper;
using MediatR;
using Property.Application.Interface.Interfaces;
using Property.Application.UseCase.Commons.Bases;
using Property.Domain.Entities;
using Property.Utilities.Constants;
using Property.Utilities.HelperExtensions;

namespace Property.Application.UseCase.UseCases.Property.Commands.AddImageCommand
{
    public class AddImagePropertyHandler : IRequestHandler<AddImagePropertyCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddImagePropertyHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(AddImagePropertyCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var propertyImage = _mapper.Map<PropertyImage>(request);
                var parameters = propertyImage.GetPropertiesWithValues();
                response.Data = await _unitOfWork.Property.ExecAsync(SP.spPropertyAddImage, parameters);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_ADD_IMAGE;
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
