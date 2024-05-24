using FluentValidation;
using OnlineVideoCourses.Domain.Entities;

namespace OnlineVideoCourse.Aplication.Common.Validators;

public class SubjectValidator : AbstractValidator<Subject>
{
    public SubjectValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Fan nomini kiriting")
            .Length(3, 40).WithMessage("Fan 3 va 40 orasida bo'lsin");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Fan haqida ma'lumot kiriting")
            .Length(3, 100).WithMessage("Fan ma'lumoti 3 va 100 orasida bo'lsin");
        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Fan Yozuvchisini kiriting")
            .Length(3, 40).WithMessage("Yozuvchi 3 va 40 orasida bo'lsin");
    }
}
