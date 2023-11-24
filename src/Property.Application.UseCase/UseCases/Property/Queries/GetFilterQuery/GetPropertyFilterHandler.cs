using AutoMapper;
using MediatR;
using Property.Application.Dtos.Property.Response;
using Property.Application.Interface.Interfaces;
using Property.Application.UseCase.Commons.Bases;
using Property.Utilities.Constants;

namespace Property.Application.UseCase.UseCases.Property.Queries.GetFilterQuery
{

    public class GetPropertyFilterHandler : IRequestHandler<GetPropertyFilterQuery, BaseResponse<IEnumerable<GetListPropertyResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPropertyFilterHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<GetListPropertyResponseDto>>> Handle(GetPropertyFilterQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetListPropertyResponseDto>>();

            try
            {
                var properties = await _unitOfWork.Property.GetFilterProperty(SP.spPropertyListFilter, request);
                GetPropertyQuery Aux = new();
                if (properties != null)
                {
                    // Cargar imágenes y trazas para cada propiedad
                    foreach (var property in properties)
                    {
                        Aux.IdProperty = property.IdProperty;
                        property.Images = await _unitOfWork.Property.GetImagesForProperty(SP.spImagesProperty, Aux);
                        property.Traces = await _unitOfWork.Property.GetTracesForProperty(SP.spTracesProperty, Aux);
                    }

                    response.IsSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<GetListPropertyResponseDto>>(properties);
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
