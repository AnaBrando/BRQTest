using Domain;

namespace Application.UseCase.CreateTrunk
{
    public class CreateTruckOutput   
    {
        public CreateTruckOutput(bool succes, Truck truck, string message)
        {
            Succes = succes;
            Truck = truck;
            Message = message;
        }

        public bool Succes {get;set;}

        public Truck Truck {get;set;}

        public string Message { get; set; }
    }
}