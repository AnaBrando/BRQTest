using System;
using FluentValidation;

public class CreateTrunkRequestValidator : AbstractValidator<CreateTruckRequest> 
{
    public CreateTrunkRequestValidator()
    {
        RuleFor(trunk => trunk.Model).NotNull().Must(ValidateModel).WithMessage("Truck's need be FH or FM");
        RuleFor(trunk => trunk.ModelYear).NotNull().GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("Truck's manufactury model year must be actual year");
        RuleFor(trunk => trunk.ManufactoryYear).NotNull().GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("Truck's model year must be actual year or more");
    }   
    private static bool ValidateModel(int model)
    {
        var result = model ==1 || model == 2;
        return result;
    }
}