using Application.UseCase.CreateTrunk;
using Domain;

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


    }
}