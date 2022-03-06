using FluentValidation;
using Store.BUSINESS.DTOs.RequestDTOs;

namespace Store.BUSINESS.Validators.GenreValidators
{
    public class CreateGenreDTOValidator : AbstractValidator<CreateGenreDTO>
    {
        public CreateGenreDTOValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required.").MaximumLength(50).
                WithMessage("Name can not be longer than 50 charachters.").MinimumLength(2).WithMessage("Name can not be shorter than 2 charachters.");
        }
    }
}
