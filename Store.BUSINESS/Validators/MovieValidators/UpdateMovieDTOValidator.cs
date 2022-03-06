using FluentValidation;
using Store.BUSINESS.DTOs.RequestDTOs;

namespace Store.BUSINESS.Validators.MovieValidators
{
    public class UpdateMovieDTOValidator : AbstractValidator<UpdateMovieDTO>
    {
        public UpdateMovieDTOValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null.").GreaterThan(0).WithMessage("Id can not be smaller than 1.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.").MaximumLength(100).WithMessage("Title can not be longer than 100 charachters.");
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("Description can not be longer than 200 charachters.");
            RuleFor(x => x.DirectorId).NotNull().WithMessage("DirectorId is required.").GreaterThan(0).WithMessage("DirectorId can not be smaller than 1.");
            RuleFor(x => x.ReleasedYear).NotEmpty().WithMessage("Released year is required.");
            RuleFor(x => x.Price).NotNull().WithMessage("Price is required.").GreaterThanOrEqualTo(0).WithMessage("Price can not be smaller than 0.");
        }
    }
}
