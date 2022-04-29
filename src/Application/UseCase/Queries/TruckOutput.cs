using Domain;
using System;

namespace Application.UseCase.Queries
{
    public sealed class TruckOutput
    {
        public TruckOutput(string id,int manufactoryYear, Model model, int modelYear)
        {
            ManufactoryYear = manufactoryYear;
            Model = model;
            ModelYear = modelYear;
            Id = id;
        }
        public string Id { get; set; }
        public Model Model { get; private set; }
        public int ManufactoryYear { get; private set; }
        public int ModelYear { get; private set; }
    }
}
