using FluentValidation;
using Weather.Data.Entities;

namespace Weather.ServiceHost.Validators
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("City name is required");
            RuleFor(c => c.CountryId).NotEmpty().WithMessage("Country id is required");
        }
    }
}
