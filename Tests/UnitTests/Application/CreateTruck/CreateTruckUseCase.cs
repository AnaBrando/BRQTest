using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Extensions.Mapping;
using Application.UseCase.CreateTrunk;
using AutoFixture;
using Domain;
using Domain.Interfaces;
using FluentAssertions;
using MediatR;
using Moq;
using Xunit;


namespace UnitTests
{
    public class CreateTruckUseCase
    {

        private readonly Fixture _fixture = new Fixture();
        private readonly DefaultFixture _Moqs = new DefaultFixture();


        [Theory]
        [InlineData(1, 2022, 2025)]
        [InlineData(2, 2022, 2022)]
        [InlineData(1, 2022, 2024)]
        [InlineData(1, 2022, 2022)]
        [InlineData(2, 2022, 2024)]
        [InlineData(2, 2022, 2030)]
        public async Task ShouldCreateTruckWithSuccess(int model, int manufactoryYear, int modelyear)
        {
            //arrange

            var request = _fixture.Build<CreateTruckRequest>()
                .With(x => x.ManufactoryYear, manufactoryYear)
                .With(x => x.ModelYear, modelyear)
                .With(x => x.Model, model)
            .Create();
            var command = request.CreateRequestToCommand();
            var output = _fixture.Build<CreateTruckOutput>()
               .With(x => x.Truck, command.CreateTruckCommandToModel())
               .With(x => x.Succes, true)
               .With(x => x.Message, Constants.CreateSuccess.SuccessDefault())
            .Create();
            //action
            _Moqs.IMediator.Setup(action => action.Send(It.IsAny<CreateTruckCommand>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(output);
            _Moqs.ITruckRepository.Setup(prop => prop.AddAsync(It.IsAny<Truck>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(command.CreateTruckCommandToModel());

            var result = await _Moqs.CreateTruckCommandHandler.Handle(command, It.IsAny<CancellationToken>());

            //assert
            result.Should().NotBeNull();
            result.Succes.Should().BeTrue();
            result.Message.Should().Be(Constants.CreateSuccess.SuccessDefault());
            result.Truck.Should().NotBeNull();
            result.Truck.ManufactoryYear.Should().Be(DateTime.Now.Year);
            result.Truck.ModelYear.Should().BeGreaterThanOrEqualTo(DateTime.Now.Year);

        }

        [Theory]
        [InlineData(2, 2025, 2025)]
        [InlineData(2, 2024, 2022)]
        [InlineData(3, 2022, 2024)]
        [InlineData(1, 2024, 2021)]
        [InlineData(3, 2030, 2018)]
        [InlineData(4, 2024, 2019)]
        public async Task ShouldNotCreateTruckWithInvalidParameters(int model, int manufactoryYear, int modelyear)
        {
            //arrange
            var request = _fixture.Build<CreateTruckRequest>()
                .With(x => x.ManufactoryYear, manufactoryYear)
                .With(x => x.ModelYear, modelyear)
                .With(x => x.Model, model)
                .Create();
            var command = request.CreateRequestToCommand();
            var output = _fixture.Build<CreateTruckOutput>()
               .With(x => x.Truck, It.IsAny<Truck>())
               .With(x => x.Succes, false)
               .With(x => x.Message, Constants.ErrorCreate.ErrorDefault().InvalidFieldsDefault())
               .Create();
            //action
            _Moqs.IMediator.Setup(action => action.Send(It.IsAny<CreateTruckCommand>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(output);
            _Moqs.ITruckRepository.Setup(prop => prop.AddAsync(It.IsAny<Truck>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(It.IsAny<Truck>());

            var result = await _Moqs.CreateTruckCommandHandler.Handle(command, It.IsAny<CancellationToken>());

            //assert
            result.Should().NotBeNull();
            result.Succes.Should().BeFalse();
            result.Message.Should().Be(Constants.ErrorCreate.ErrorDefault().InvalidFieldsDefault());
            result.Truck.Should().BeNull();

        }
        [Theory]
        [InlineData(1, 2022, 2025)]
        [InlineData(2, 2022, 2022)]
        [InlineData(1, 2022, 2024)]
        [InlineData(1, 2022, 2022)]
        [InlineData(2, 2022, 2024)]
        [InlineData(2, 2022, 2030)]
        public async Task ShouldNotCreateTruckWithError(int model, int manufactoryYear, int modelyear)
        {
            //arrange
            var request = _fixture.Build<CreateTruckRequest>()
                .With(x => x.ManufactoryYear, manufactoryYear)
                .With(x => x.ModelYear, modelyear)
                .With(x => x.Model, model)
                .Create();
            var command = request.CreateRequestToCommand();
            var output = _fixture.Build<CreateTruckOutput>()
               .With(x => x.Truck, It.IsAny<Truck>())
               .With(x => x.Succes, false)
               .With(x => x.Message, Constants.ErrorCreate.SuccessDefault().ErrorDefault())
               .Create();
            //action
            _Moqs.IMediator.Setup(action => action.Send(It.IsAny<CreateTruckCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(output);
            
            _Moqs.ITruckRepository.Setup(prop => prop.AddAsync(It.IsAny<Truck>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(It.IsAny<Truck>());

            var result = await _Moqs.CreateTruckCommandHandler.Handle(command, It.IsAny<CancellationToken>());

            //assert
            result.Should().NotBeNull();
            result.Succes.Should().BeFalse();
            result.Message.Should().Be(Constants.ErrorCreate.ErrorDefault());
            result.Truck.Should().BeNull();

        }
    }
}
