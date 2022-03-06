﻿using FluentValidation;
using Store.BUSINESS.DTOs.RequestDTOs;

namespace Store.BUSINESS.Validators.ActorValidators
{
    public class CreateActorDTOValidator : AbstractValidator<CreateActorDTO>
    {
        public CreateActorDTOValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Firstname is required.").MaximumLength(50).WithMessage("Firstname can not be longer than 50 charachters.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lastname is required.").MaximumLength(50).WithMessage("Lastname can not be longer than 50 charachters.");
        }
    }
}
