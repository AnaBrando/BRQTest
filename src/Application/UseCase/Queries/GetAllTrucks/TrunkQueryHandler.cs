using Application.Extensions.Mapping;
using Application.UseCase.Queries.GetAllTrucks;
using Domain;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCase.Queries.GetAllTruck
{
    public class TrunkQueryHandler : IRequestHandler<ListTrucksQuery, ListTrucksOutput>
    {
        private readonly ITruckRepository _truckRepository;

        public TrunkQueryHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }
        public async Task<ListTrucksOutput> Handle(ListTrucksQuery request, CancellationToken cancellationToken)
        {
            ListTrucksOutput output;
            var result = await _truckRepository.GetAll(cancellationToken).ConfigureAwait(false);
            if(result is null || result.Count == 0)
            {
                output = new ListTrucksOutput(null, false);
                return output;
            }
            output = new ListTrucksOutput(result.MapToTruckOutput(), true);
            return output;
        }
    }
}
