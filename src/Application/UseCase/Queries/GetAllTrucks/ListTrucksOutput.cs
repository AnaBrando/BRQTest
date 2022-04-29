using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Queries.GetAllTrucks
{
    public class ListTrucksOutput
    {
        public ListTrucksOutput(List<TruckOutput> trucks, bool success)
        {
            Trucks = trucks ?? new List<TruckOutput>();
            Success = success;
        }

        public List<TruckOutput> Trucks { get; set; }
        public bool Success { get; set; }
    }
}
