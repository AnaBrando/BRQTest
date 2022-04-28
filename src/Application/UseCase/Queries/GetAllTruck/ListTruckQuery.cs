using Domain;
using MediatR;
using System.Collections.Generic;

namespace Application.UseCase.Queries.GetAllTruck
{
 
    public class ListTruckQuery : IRequest<IEnumerable<Truck>>
    {
    }
}
