using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Weather.RA.Interfaces;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Validators
{
    public class UpdateCityValidator : AbstractValidator<UpdateCityDTO>
    {
        private readonly ICityRepository _cityRepository;

        public UpdateCityValidator(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
            RuleFor(c => c.Name).NotEmpty().WithMessage("City name is required");
            RuleFor(c => c.CountryId).NotEmpty().WithMessage("Country id is required");
            RuleFor(c => c.Name).MustAsync((n, cancellationToken) => BeUniqueNameAsync(n)).WithMessage("City name must be unique");
        }

        protected async Task<bool> BeUniqueNameAsync(string name)
        {
            var cities = await _cityRepository.GetAllAsync();
            return !cities.Select(c => c.Name).Contains(name);
        }
    }
}
