using AutoMapper;
using MediatR;
using Property.Application.Dtos.Owner.Response;
using Property.Application.Interface.Interfaces;
using Property.Application.UseCase.Commons.Bases;
using Property.Utilities.Constants;

namespace Property.Application.UseCase.UseCases.Owner.Queries.GetByIdQuery
{
    public class OwnerByIdHandler : IRequestHandler<GetOwnerByIdQuery, BaseResponse<GetOwnerByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OwnerByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetOwnerByIdResponseDto>> Handle(GetOwnerByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetOwnerByIdResponseDto>();

            try
            {
                var owner = await _unitOfWork.Owner.GetByIdAsync(SP.spOwnerById,request);

                if (owner is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessages.MESSAGE_QUERY_EMPTY;
                    return response;
                }
                response.IsSuccess = true;
                response.Data = _mapper.Map<GetOwnerByIdResponseDto>(owner);
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
