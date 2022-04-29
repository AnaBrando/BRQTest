using Application.Extensions.Mapping;
using Application.UseCase.CreateTrunk;
using AutoFixture;
using Domain;
using FluentAssertions;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Specs.Steps
{
    [Binding]
    public class CreateTruckSteps
    {
        private DefaultFixture DefaultFixture = new DefaultFixture();
        private readonly Fixture _fixture = new Fixture();

        private ScenarioContext _scenarioContext;

        public CreateTruckSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"the model (.*)")]
        public void GivenTheModel(int model)
        {
            _scenarioContext["Model"] = (Model)model;
        }

        [Given(@"model year (.*)")]
        public void GivenModelYear(int modelYear)
        {
            _scenarioContext["ModelYear"] = modelYear;
        }

        [Given(@"Manufactory year (.*)")]
        public void GivenManufactoryYear(int manufactoryYear)
        {
            _scenarioContext["ManufactoryYear"] = manufactoryYear;
        }

        [When(@"a request for create truck is require")]
        public void WhenARequestForCreateTruckIsRequire()
        {
            var command = new CreateTruckCommand(
                (int)_scenarioContext["ManufactoryYear"],
                (int)_scenarioContext["Model"],
                (int)_scenarioContext["ManufactoryYear"]);
            _scenarioContext["Command"] = command;
        }
        [When(@"was Valid")]
        public void WhenWasValid()
        {
            var command = (CreateTruckCommand)_scenarioContext["Command"];
            var output = _fixture.Build<CreateTruckOutput>()
                    .With(prop => prop.Success, true)
                    .With(prop => prop.Truck, command.CreateTruckCommandToModel())
                    .With(prop => prop.Message, Constants.CreateSuccess.SuccessDefault())
                .Create();

            DefaultFixture.ITruckRepository.Setup(action => action.AddAsync(It.IsAny<Truck>(), It.IsAny<CancellationToken>())).ReturnsAsync(command.CreateTruckCommandToModel());
           
            DefaultFixture.IMediator.Setup(action => action.Send(It.IsAny<CreateTruckCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(output);

        }

        [Then(@"the truck must create")]
        public async Task ThenTheTruckMustCreate()
        {
            var command = (CreateTruckCommand)_scenarioContext["Command"];
            var result = await DefaultFixture.CreateTruckCommandHandler.Handle(command, It.IsAny<CancellationToken>());
            result.Should().NotBeNull();
            result.Message.Should().Be(Constants.CreateSuccess.SuccessDefault());
            result.Success.Should().BeTrue();
            result.Truck.Should().BeOfType<Truck>();
        }
        [When(@"is Valid")]
        public void WhenIsValid()
        {
            var command = (CreateTruckCommand)_scenarioContext["Command"];
            var output = _fixture.Build<CreateTruckOutput>()
               .With(prop => prop.Success, true)
               .With(prop => prop.Truck, command.CreateTruckCommandToModel())
               .With(prop => prop.Message, Constants.CreateSuccess.SuccessDefault())
               .Create();
            Constants.CreateSuccess.ErrorDefault().Should().BeOfType<string>();
            DefaultFixture.ITruckRepository.Setup(action => action.AddAsync(It.IsAny<Truck>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(command.CreateTruckCommandToModel());
        }

        [When(@"is Invalid")]
        public void WhenIsInvalid()
        {
            var command = (CreateTruckCommand)_scenarioContext["Command"];
            var output = _fixture.Build<CreateTruckOutput>()
               .With(prop => prop.Success, false)
               .With(prop => prop.Truck, It.IsAny<Truck>())
               .With(prop => prop.Message, Constants.ErrorCreate.ErrorDefault())
               .Create();
           
            DefaultFixture.ITruckRepository.Setup(action => action.AddAsync(It.IsAny<Truck>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(It.IsAny<Truck>());
        }


        [Then(@"the truck is not create")]
        public async Task ThenTheTruckIsNotCreate()
        {
            var command = (CreateTruckCommand)_scenarioContext["Command"];
            var result = await DefaultFixture.CreateTruckCommandHandler.Handle(command, It.IsAny<CancellationToken>());
            result.Should().NotBeNull();
            result.Message.Should().Be(Constants.ErrorCreate.ErrorDefault().InvalidFieldsDefault());
            result.Success.Should().BeFalse();
            result.Truck.Should().BeNull();
        }

    }
}
