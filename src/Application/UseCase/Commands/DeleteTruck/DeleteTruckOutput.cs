using Domain;

namespace Application.UseCase.CreateTrunk
{
    public class DeleteTruckOutput   
    {
        public DeleteTruckOutput(bool succes, string message)
        {
            Succes = succes;
            Message = message;
        }

        public bool Succes {get;set;}
        public string Message { get; set; }
    }
}