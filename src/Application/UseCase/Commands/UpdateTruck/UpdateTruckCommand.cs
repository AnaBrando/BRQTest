using Domain;
using MediatR;
using System;

namespace Application.UseCase.CreateTrunk
{
    public class UpdateTruckCommand : IRequest<UpdateTruckOutput>
  {
        public UpdateTruckCommand(string id, int model, int manufactoryYear, int modelYear)
        {
            Id = id;
            ManufactoryYear = manufactoryYear;
            Model = (Model)model;
            ModelYear = modelYear;
        }
        public string Id { get; private set; }
        public Model Model { get; private set; }
        public int ManufactoryYear { get; private set; }
        public int ModelYear {get; private set; }

    }
}
