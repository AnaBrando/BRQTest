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
    public class ListUsersQueryHandler : IRequestHandler<ListTruckQuery, IEnumerable<Truck>>
    {
        private readonly ITruckRepository _truckRepository;

        public ListUsersQueryHandler(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<IEnumerable<Truck>> Handle(ListTruckQuery request, CancellationToken cancellationToken)
        {
            return await _truckRepository.GetAll(cancellationToken);
        }
    }
}
