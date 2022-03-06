using FluentValidation;
using Store.BUSINESS.DTOs.RequestDTOs;

namespace Store.BUSINESS.Validators.GenreValidators
{
    public class UpdateGenreDTOValidator : AbstractValidator<UpdateGenreDTO>
    {
        public UpdateGenreDTOValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null.").GreaterThan(0).WithMessage("Id can not be smaller than 1.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").
                MaximumLength(50).WithMessage("Name can not be longer than 50 charachters.").MinimumLength(2).WithMessage("Name can not be shorter than 2 charachters.");
        }
    }
}
