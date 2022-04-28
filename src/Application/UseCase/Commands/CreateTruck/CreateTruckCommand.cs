using Domain;
using MediatR;

namespace Application.UseCase.CreateTrunk
{
    public class CreateTruckCommand : IRequest<CreateTruckOutput>
  {
        public CreateTruckCommand(int manufactoryYear, int model, int modelYear)
        {
            ManufactoryYear = manufactoryYear;
            Model = (Model)model;
            ModelYear = modelYear;
        }

        public Model Model { get; private set; }
        public int ManufactoryYear { get; private set; }
        public int ModelYear {get; private set; }

        
  }
}
