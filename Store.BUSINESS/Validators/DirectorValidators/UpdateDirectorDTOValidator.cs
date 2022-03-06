using FluentValidation;
using Store.BUSINESS.DTOs.RequestDTOs;

namespace Store.BUSINESS.Validators.DirectorValidators
{
    public class UpdateDirectorDTOValidator : AbstractValidator<UpdateDirectorDTO>
    {
        public UpdateDirectorDTOValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null.").GreaterThan(0).WithMessage("Id can not be smaller than 1.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Firstname is required.").MaximumLength(50).WithMessage("Firstname can not be longer than 50 charachters.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lastname is required.").MaximumLength(50).WithMessage("Lastname can not be longer than 50 charachters.");
        }
    }
}
