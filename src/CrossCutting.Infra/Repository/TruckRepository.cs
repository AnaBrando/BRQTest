using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;

namespace CrossCutting.Infra.Repository
{
    public class TruckRepository : ITruckRepository
    {
        public Task<Truck> AddAsync(Truck entity, CancellationToken cancellationToken)
        {
           throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Truck>> GetAll(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<Truck> UpdateAsync(string id, Truck entity, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}