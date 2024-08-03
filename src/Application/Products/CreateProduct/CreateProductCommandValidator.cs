﻿using FluentValidation;

namespace Application.Products.CreateProduct;
internal sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Description).NotEmpty();
        RuleFor(p => p.ImagePath).NotEmpty();
    }
}
