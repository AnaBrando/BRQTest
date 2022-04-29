using Domain;

namespace Application.UseCase.CreateTrunk
{
    public class UpdateTruckOutput
    {
        public UpdateTruckOutput(bool succes, string message)
        {
            Success = succes;
            Message = message;
        }

        public bool Success {get;set;}

        public string Message { get; set; }
    }
}