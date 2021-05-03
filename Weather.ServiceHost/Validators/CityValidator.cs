using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Weather.RA.Interfaces;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Validators
{
    public class CityValidator : AbstractValidator<CreateCityDTO>
    {
        private readonly ICityRepository _cityRepository;

        public CityValidator(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
            RuleFor(c => c.Name).NotEmpty().WithMessage("City name is required");
            RuleFor(c => c.CountryId).NotEmpty().WithMessage("Country id is required");
            RuleFor(c => c.Name).MustAsync((n, cancellationToken) => BeValidNameAsync(n));
        }

        protected async Task<bool> BeValidNameAsync(string name)
        {
            var cities = await _cityRepository.GetAllAsync();
            return !cities.Select(c => c.Name).Contains(name);
        }
    }
}
}
