using Application.UseCase.CreateTrunk;
using Presentation.Transport;
using System;

public static class CreateTrunkMapping
{

    public static CreateTruckCommand CreateRequestToCommand(this CreateTruckRequest create)
    {
        return new CreateTruckCommand(create.ManufactoryYear, create.Model, create.ModelYear);
    }
    public static UpdateTruckCommand UpdateRequestToCommand(this UpdateTruckRequest update)
    {
        return new UpdateTruckCommand(update.Id, update.Model, update.ManufactoryYear, update.ModelYear);
    }
    public static DeleteTruckCommand DeleteRequestToCommand(this DeleteTruckRequest delete)
    {
        return new DeleteTruckCommand(delete.Id);
    }
    
}