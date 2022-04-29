using Application.UseCase.CreateTrunk;
using Application.UseCase.Queries;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Application.Extensions.Mapping
{
    public static class TruckCommandMapping
    {
        public static Truck CreateTruckCommandToModel(this CreateTruckCommand create)
        {
            return new Truck(create.ManufactoryYear,create.Model,create.ModelYear);
        }
        public static Truck UpdateTruckCommandToModel(this UpdateTruckCommand create)
        {
            return new Truck(create.ManufactoryYear, create.Model, create.ModelYear);
        }
        public static List<TruckOutput> MapToTruckOutput(this List<Truck> list)
        {
            var result = list.Select(x => new TruckOutput(x.Id.ToString(), x.ManufactoryYear, x.Model, x.ModelYear)).ToList();
            return result;
        }

    }
}