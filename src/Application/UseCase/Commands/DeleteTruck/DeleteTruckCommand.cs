using Domain;
using MediatR;

namespace Application.UseCase.CreateTrunk
{
    public class DeleteTruckCommand : IRequest<DeleteTruckOutput>
    {
        public DeleteTruckCommand(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }
    }
}
