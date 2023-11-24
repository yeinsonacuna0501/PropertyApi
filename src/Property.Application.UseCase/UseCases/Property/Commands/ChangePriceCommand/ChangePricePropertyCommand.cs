using MediatR;
using Property.Application.UseCase.Commons.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.UseCase.UseCases.Property.Commands.ChangePriceCommand
{
    public class ChangePricePropertyCommand : IRequest<BaseResponse<bool>>
    {
        public int? IdProperty { get; set; }

        public decimal? Price { get; set; }
    }
}
