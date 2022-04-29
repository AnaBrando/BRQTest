using System;

namespace Domain
{
    public sealed class Truck
    {
        private Model model;

        public Truck(int manufactoryYear, Model model, int modelYear)
        {
            ManufactoryYear = manufactoryYear;
            this.model = model;
            Model = model;
            ModelYear = modelYear;
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Model Model { get; private set; }
        public int ManufactoryYear { get; private set; }
        public int ModelYear { get; private set; }

        public Truck Update(Truck other)
        {
            Model = other.Model;
            ManufactoryYear = other.ManufactoryYear;
            ModelYear = other.ModelYear;
            return this;
        }

    }
}
