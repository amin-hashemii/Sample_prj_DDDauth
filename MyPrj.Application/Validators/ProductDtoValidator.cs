using FluentValidation;
using MyPrj.Application.Products.Command;
using MyPrj.Application.ViewModel;

namespace MyPrj.Application.Validators;

public class ProductDtoValidator:AbstractValidator<AddProductCommand>
{
    public ProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(100).WithMessage("نام نمی‌تواند بیشتر از ۱۰۰ کاراکتر باشد")
            .MinimumLength(2).WithMessage("نام کارکتر نمیتواند کمتر از دو حرف باشد");
    }
}