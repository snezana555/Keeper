using FluentValidation;
using Keeper.WebService.Dto;

namespace Keeper.WebService.Validators
{
    public class RequestCreationDtoValidator:  AbstractValidator<RequestCreationDto>
    {
        public RequestCreationDtoValidator() 
        {
            RuleFor(dto => dto.DateStart).NotEmpty().WithMessage("Дата начала обязательна для заполнения");
            RuleFor(dto => dto.DateEnd)
                .NotEmpty().WithMessage("Дата окончания обязательна для заполнения")
                .GreaterThanOrEqualTo(dto => dto.DateStart).WithMessage("Дата окончания не может быть раньше даты начала");
                //.LessThanOrEqualTo(dto => dto.DateStart + DateTime(15)).WithMessage("Дата окончания не может быть раньше даты начала");
            RuleFor(dto => dto.TargetVisit).NotEmpty().WithMessage("Цель посещения обязательна для заполнения");
            RuleFor(dto => dto.AdditionalFiles).NotEmpty().WithMessage("Дополнительные файлы обязательны для заполнения");
            RuleFor(dto => dto.EmployeeId).NotEmpty().WithMessage("Идентификатор сотрудника обязателен для заполнения");
            RuleFor(dto => dto.VisitorsIds).NotEmpty().WithMessage("Списки идентификаторов обязательны для заполнения")
                .ForEach(visitorId => {
                    visitorId.NotEmpty().WithMessage("Идентификатор посетителя не может быть пустым");
            });
            RuleFor(dto => dto.StatusDescription).MaximumLength(100).WithMessage("Описание не должно превышать 100 символов");
        }
    }
}
