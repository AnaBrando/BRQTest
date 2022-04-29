using Domain;

namespace Application.UseCase.CreateTrunk
{
    public class CreateTruckOutput   
    {
        public CreateTruckOutput(bool succes, Truck truck, string message)
        {
            Success = succes;
            Truck = truck;
            Message = message;
        }

        public bool Success {get;set;}

        public Truck Truck {get;set;}

        public string Message { get; set; }
    }
}