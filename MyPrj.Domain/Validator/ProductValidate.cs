using FluentValidation;
using MyPrj.Domain.Models;

namespace MyPrj.Domain.Validator;

public class ProductValidate:AbstractValidator<product>
{
    public ProductValidate()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("نام محصول الزامی است");
    }
}