﻿

using FluentValidation;
using Keeper.WebService.Dto;

namespace Keeper.WebService.Validators
{
    public class VisitorValidator : AbstractValidator<VisitorCreationDto>
    {
        public VisitorValidator() 
        {
            RuleFor(dto => dto.Surname).NotEmpty().WithMessage("Фамилия посетителя обязательна для заполнения");
            RuleFor(dto => dto.Name).NotEmpty().WithMessage("Имя посетителя обязательно для заполнения");
            RuleFor(dto => dto.Email).NotEmpty().WithMessage("Почта посетителя обязательна для заполнения")
                    .EmailAddress().WithMessage("Почта посетителя неккоректна");
            RuleFor(dto => dto.Remark).NotEmpty().WithMessage("Примечание посетителя обязательно для заполнения");
            RuleFor(dto => dto.DateBoth).NotEmpty().WithMessage("Дата рождения обязательна для заполнения");
            RuleFor(dto => dto.PassportData).NotEmpty().WithMessage("Паспортные данные обязательны для заполнения");
        }
    }
}
