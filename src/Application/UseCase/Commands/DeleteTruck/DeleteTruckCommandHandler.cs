using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Extensions.Mapping;
using Domain;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCase.CreateTrunk
{

    public class DeleteTruckCommandHandler : IRequestHandler<DeleteTruckCommand, DeleteTruckOutput>
    {
        private readonly ITruckRepository _repository;
        public DeleteTruckCommandHandler(ITruckRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteTruckOutput> Handle(DeleteTruckCommand request, CancellationToken cancellationToken = default)
        {
            DeleteTruckOutput output;
            var result = await _repository.DeleteAsync(request.Id, cancellationToken);
            if (!result)
            {
                output = new DeleteTruckOutput(false, Constants.DeleteError.ErrorDefault());
                return output;
            }
            output = new DeleteTruckOutput(true, Constants.DeleteSuccess.SuccessDefault());
            return output;
        }
    }

}
