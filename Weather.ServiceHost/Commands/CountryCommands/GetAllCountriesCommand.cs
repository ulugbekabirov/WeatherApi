﻿using MediatR;
using System.Collections.Generic;
using Weather.SDK.DTO;

namespace Weather.ServiceHost.Commands.CountryCommands
{
    public class GetCountryCommand: IRequest<IEnumerable<CountryDTO>>
    {
    }
}