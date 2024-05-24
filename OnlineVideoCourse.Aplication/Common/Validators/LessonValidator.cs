using FluentValidation;
using OnlineVideoCourses.Domain.Entities;
using System.Data;

namespace OnlineVideoCourse.Aplication.Common.Validators;

public class LessonValidator : AbstractValidator<Lesson>
{
    public LessonValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nomi Bo'sh bo'lmasligi lozim")
            .Length(4, 16).WithMessage("Nomi 4 va 16 orali'gida bolishi lozim");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description kiritilishi shaet")
            .Length(5, 160).WithMessage("Description 5 va 160 orlig'ida bolishi shart!");
    }
}
