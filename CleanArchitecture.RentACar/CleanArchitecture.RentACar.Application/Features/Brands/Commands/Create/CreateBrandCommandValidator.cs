using FluentValidation;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommandRequest> // AbstractValidator bir IValidator'dur.
{
    public CreateBrandCommandValidator() 
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3); // Name boş olamaz ve en fazla 3 karakter olabilir.RuleFor AbstractValidator sınıfının bir metodu.
    }
}