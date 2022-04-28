using Domain;

namespace Application.UseCase.CreateTrunk
{
    public class UpdateTruckOutput
    {
        public UpdateTruckOutput(bool succes, string message)
        {
            Succes = succes;
            Message = message;
        }

        public bool Succes {get;set;}

        public string Message { get; set; }
    }
}