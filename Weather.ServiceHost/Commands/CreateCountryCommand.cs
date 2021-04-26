using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Data.Entities;

namespace Weather.ServiceHost.Commands
{
    public class CreateCountryCommand: IRequest
    {
        public Country Country { get; set; }
    }
}
