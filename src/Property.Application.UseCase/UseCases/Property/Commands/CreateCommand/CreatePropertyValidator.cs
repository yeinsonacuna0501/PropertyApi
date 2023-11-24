using FluentValidation;

namespace Property.Application.UseCase.UseCases.Property.Commands.CreateCommand
{
    public class CreatePropertyValidator : AbstractValidator<CreatePropertyCommand>
    {
        public CreatePropertyValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo nombre no puede ser vacio");
        }
    }
}
