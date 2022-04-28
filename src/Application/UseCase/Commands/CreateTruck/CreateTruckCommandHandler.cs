using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Extensions.Mapping;
using Domain;
using Domain.Interfaces;
using MediatR;

namespace Application.UseCase.CreateTrunk
{
   
    public class CreateTruckCommandHandler : IRequestHandler<CreateTruckCommand, CreateTruckOutput>
    {
        private readonly ITruckRepository _repository;
        public CreateTruckCommandHandler(ITruckRepository repository){
                _repository = repository;
        }

        public async Task<CreateTruckOutput> Handle(CreateTruckCommand request, CancellationToken cancellationToken = default)
        {
            CreateTruckOutput output;
            if (ValidateCommandFields(request))
            {
                var result = await _repository.AddAsync(request.CreateTruckCommandToModel(), cancellationToken);
                if (result is null)
                {
                    output = new CreateTruckOutput(false, result, Constants.ErrorCreate.ErrorDefault());
                    return output;
                }
                output = new CreateTruckOutput(true, result, Constants.CreateSuccess.SuccessDefault());
                return output;
            }
            return output = new CreateTruckOutput(false, null, Constants.ErrorCreate.ErrorDefault().InvalidFieldsDefault());
        }
        private static bool ValidateCommandFields(CreateTruckCommand requestObj)
        {
            return (requestObj.ManufactoryYear.Equals(DateTime.Now.Year)
                && requestObj.ModelYear >= DateTime.Now.Year
                && (Model)requestObj.Model is (Model.FH or Model.FM));
        }
    }
}