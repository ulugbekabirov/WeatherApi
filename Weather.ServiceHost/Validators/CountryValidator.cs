using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Weather.Data.Entities;

namespace Weather.ServiceHost.Validators
{
    public class CountryValidator : AbstractValidator<Country>
    {
        private const int MinAlphaCodeLength = 2;
        private const int MaxAlphaCodeLength = 3;

        public CountryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Country name is required");
            RuleFor(c => c.AlphaCode).NotEmpty().WithMessage("AlphaCode of country is required")
                                     .Length(MinAlphaCodeLength, MaxAlphaCodeLength).WithMessage("AlphaCode length is either 2 or 3");
        }
    }
}
