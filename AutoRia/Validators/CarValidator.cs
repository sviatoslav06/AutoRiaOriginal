using DataAccess.Data.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AutoRia.Validators
{
    public class CarValidator : AbstractValidator<Cars>
    {
        public CarValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Brand).NotNull().WithMessage("Enter {PropertyName}!")
                .Length(2, 20).WithMessage("Enter normal {PropertyName}!");
            RuleFor(x => x.Model).NotNull().WithMessage("Enter {PropertyName}!")
                .Length(2, 20).WithMessage("Enter normal {PropertyName}!");
            RuleFor(x => x.Phone).NotNull().WithMessage("Enter {PropertyName}!")
                .Length(10, 10).WithMessage("{PropertyName} length must be 10!");
            RuleFor(x => x.Engine).NotNull().WithMessage("Enter {PropertyName}!")
                .GreaterThan(0).WithMessage("Enter normal {PropertyName}!");
            RuleFor(x => x.State_number).NotNull().WithMessage("Enter {PropertyName}!")
                .Length(8, 8).WithMessage("{PropertyName} length must be 8!");
            RuleFor(x => x.Color).NotNull().WithMessage("Enter {PropertyName}!")
                .Length(3, 20).WithMessage("Enter normal {PropertyName}!");
            RuleFor(x => x.Year).NotNull().WithMessage("Enter {PropertyName}!")
                .GreaterThan(1900).WithMessage("Enter normal {PropertyName}!");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Enter valid {PropertyName}!");
            RuleFor(x => x.Price).NotNull().WithMessage("Enter {PropertyName}!")
                .GreaterThan(1).WithMessage("{PropertyName} can not be less than 1!");
            RuleFor(x => x.ImageUrl).Must(ValidateUrl).WithMessage("{PropertyName} must contain valid URL address!");
            RuleFor(x => x.City).NotNull().WithMessage("Enter {PropertyName}!")
                .Length(3, 15).WithMessage("{PropertyName} must contain 3 - 15 symbols!");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Enter more than 10 symbols!");
        }
        public bool ValidateUrl(string? uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                return true;
            }
            return Uri.TryCreate(uri, UriKind.Absolute, out _);
        }
    }
}
