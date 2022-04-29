using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Domain.Interfaces;

namespace CrossCutting.Infra.Repository
{
    public class TruckRepository : ITruckRepository
    {
        private readonly ApplicationContext _context;

        public TruckRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Truck> AddAsync(Truck entity, CancellationToken cancellationToken)
        {

            var result = await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var model = await _context.Set<Truck>().FindAsync(Guid.Parse(id));
            if (model is null)
            {
                return false;
            }
            _context.Remove(model);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<Truck>> GetAll(CancellationToken cancellationToken)
        {

            return _context.Set<Truck>().ToList();
        }
        public async Task<Truck> UpdateAsync(string id, Truck entity, CancellationToken cancellationToken)
        {
            var model = await _context.Set<Truck>().FindAsync(Guid.Parse(id));
            if (model is null) { return null; }
            var update = model.Update(entity);
            _context.Set<Truck>().Update(update);
            await _context.SaveChangesAsync(cancellationToken);
            return update;
        }

    }
}