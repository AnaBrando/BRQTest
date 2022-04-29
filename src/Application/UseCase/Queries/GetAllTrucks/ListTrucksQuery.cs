using Application.UseCase.Queries.GetAllTrucks;
using Domain;
using MediatR;
using System.Collections.Generic;

namespace Application.UseCase.Queries.GetAllTruck
{
 
    public class ListTrucksQuery : IRequest<ListTrucksOutput>
    {
    }
}
