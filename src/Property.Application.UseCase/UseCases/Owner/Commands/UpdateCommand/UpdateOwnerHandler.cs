using AutoMapper;
using MediatR;
using Property.Application.Interface.Interfaces;
using Property.Application.UseCase.Commons.Bases;
using Property.Utilities.Constants;
using Property.Utilities.HelperExtensions;
using Entity = Property.Domain.Entities;

namespace Property.Application.UseCase.UseCases.Owner.Commands.UpdateCommand
{

    public class UpdateOwnerHandler : IRequestHandler<UpdateOwnerCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateOwnerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<bool>> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var owner = _mapper.Map<Entity.Owner>(request);
                var parameters = owner.GetPropertiesWithValues();
                response.Data = await _unitOfWork.Owner.ExecAsync(SP.spOwnerEdit, parameters);

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
