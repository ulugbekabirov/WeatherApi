﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Weather.Data.Entities;
using Weather.RA.Interfaces;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Handlers.CountryHandlers
{
    public class UpdateCountryRequest : IRequest<IActionResult>
    {
        public Guid Id { get; set; }

        public UpdateCountryDTO Country { get; set; }
    }

    public class UpdateCountryHandler : IRequestHandler<UpdateCountryRequest, IActionResult>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public UpdateCountryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(UpdateCountryRequest request, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetByIdAsync(request.Id);
            if (country.Version > request.Country.Version)
            {
                return new ConflictObjectResult("Version mismatch");
            }

            country = _mapper.Map<Country>(request.Country);
            await _countryRepository.UpdateAsync(country);
            return new NoContentResult();
        }
    }
}
