using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Extensions.Mapping;
using Domain;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCase.CreateTrunk
{

    public class UpdateTruckCommandHandler : IRequestHandler<UpdateTruckCommand, UpdateTruckOutput>
    {
        private readonly ITruckRepository _repository;
        public UpdateTruckCommandHandler(ITruckRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateTruckOutput> Handle(UpdateTruckCommand request, CancellationToken cancellationToken = default)
        {
            UpdateTruckOutput output;
            if (ValidateCommandFields(request))
            {
                var result = await _repository.UpdateAsync(request.Id.ToString(), request.UpdateTruckCommandToModel(), cancellationToken);
                if (result is null)
                {
                    output = new UpdateTruckOutput(false, Constants.UpdateError.ErrorDefault());
                    return output;
                }
                output = new UpdateTruckOutput(true, Constants.UpdateSuccess.SuccessDefault());
                return output;
            }
            return output = new UpdateTruckOutput(false, Constants.UpdateError.InvalidFieldsDefault());
        }
        private bool ValidateCommandFields(UpdateTruckCommand requestObj)
        {
            return (requestObj.ManufactoryYear.Equals(DateTime.Now.Year)
                && requestObj.ModelYear >= DateTime.Now.Year
                && requestObj.Model is (Model.FH or Model.FM));
        }
    }
}