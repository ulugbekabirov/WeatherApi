using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Weather.Data.Entities;
using Weather.RA.Interfaces;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Validators
{
    public class CountryValidator : AbstractValidator<CreateCountryDTO>
    {
        private const int MinAlphaCodeLength = 2;
        private const int MaxAlphaCodeLength = 3;
        private readonly ICountryRepository _countryRepository;

        public CountryValidator(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
            RuleFor(c => c.Name).NotEmpty().WithMessage("Country name is required");
            RuleFor(c => c.AlphaCode).NotEmpty().WithMessage("AlphaCode of country is required")
                                     .Length(MinAlphaCodeLength, MaxAlphaCodeLength).WithMessage("AlphaCode length is either 2 or 3");
            RuleFor(c => c.Name).MustAsync((n, cancellationToken) => BeValidNameAsync(n));
        }

        protected async Task<bool> BeValidNameAsync(string name)
        {
            var countries = await _countryRepository.GetAllAsync();
            return !countries.Select(c => c.Name).Contains(name);
        }
    }
}
