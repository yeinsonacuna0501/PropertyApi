using AutoMapper;
using MediatR;
using Property.Application.Dtos.Owner.Response;
using Property.Application.Interface.Interfaces;
using Property.Application.UseCase.Commons.Bases;
using Property.Utilities.Constants;

namespace Property.Application.UseCase.UseCases.Owner.Queries.GetAllQuery
{
    public class GetAllOwnerHandler : IRequestHandler<GetAllOwnerQuery, BaseResponse<IEnumerable<GetAllOwnerResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllOwnerHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<IEnumerable<GetAllOwnerResponseDto>>> Handle(GetAllOwnerQuery request, CancellationToken cancellationToken)
        {
            var response =new BaseResponse<IEnumerable<GetAllOwnerResponseDto>>();

            try
            {
                var owner = await _unitOfWork.Owner.GetAllAsync(SP.spOwnerList);
                if(owner is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<GetAllOwnerResponseDto>>(owner);
                    response.Message = GlobalMessages.MESSAGE_QUERY;
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
