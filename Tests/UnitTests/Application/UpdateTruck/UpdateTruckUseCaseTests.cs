using Application.Extensions.Mapping;
using Application.UseCase.CreateTrunk;
using AutoFixture;
using Domain;
using FluentAssertions;
using Moq;
using Presentation.Transport;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.UpdateTruckUseCaseTests
{
    public class UpdateTruckUseCaseTests
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
        [InlineData(1, 2022, 2026)]
        [InlineData(2, 2022, 2027)]
        [InlineData(2, 2022, 2031)]
        [InlineData(1, 2022, 2031)]
        public async Task ShouldUpdateTruckWithSuccess(int model, int manufactoryYear, int modelyear)
        {
            //arrange

            var request = _fixture.Build<UpdateTruckRequest>()
                .With(x => x.ManufactoryYear, manufactoryYear)
                .With(x => x.ModelYear, modelyear)
                .With(x => x.Model, model)
                .With(x => x.Id, Guid.NewGuid().ToString())
                .Create();
            var command = request.UpdateRequestToCommand();
            var output = _fixture.Build<UpdateTruckOutput>()
               .With(x => x.Success, true)
               .With(x => x.Message, Constants.UpdateSuccess.SuccessDefault())
               .Create();
            //action
            _Moqs.IMediator.Setup(action => action.Send(It.IsAny<UpdateTruckCommand>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(output);
            _Moqs.ITruckRepository.Setup(prop => prop.UpdateAsync(It.IsAny<string>(), It.IsAny<Truck>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(command.UpdateTruckCommandToModel());

            var result = await _Moqs.UpdateTruckCommandHandler.Handle(command, It.IsAny<CancellationToken>());

            //assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Message.Should().Be(Constants.UpdateSuccess.SuccessDefault());


        }

        [Theory]
        [InlineData(2, 2025, 2025)]
        [InlineData(2, 2024, 2022)]
        [InlineData(3, 2022, 2024)]
        [InlineData(1, 2024, 2021)]
        [InlineData(3, 2030, 2018)]
        [InlineData(4, 2024, 2019)]
        [InlineData(5, 2024, 2021)]
        [InlineData(6, 2030, 2018)]
        [InlineData(7, 2024, 2019)]
        [InlineData(8, 2024, 2019)]
        public async Task ShouldNotUpdateTruckWithInvalidParameters(int model, int manufactoryYear, int modelyear)
        {
            //arrange
            var request = _fixture.Build<UpdateTruckRequest>()
                .With(x => x.ManufactoryYear, manufactoryYear)
                .With(x => x.ModelYear, modelyear)
                .With(x => x.Model, model)
                .Create();
            var command = request.UpdateRequestToCommand();
            var output = _fixture.Build<UpdateTruckOutput>()
               .With(x => x.Success, false)
               .With(x => x.Message, Constants.UpdateError.ErrorDefault().InvalidFieldsDefault())
               .Create();
            //action
            _Moqs.IMediator.Setup(action => action.Send(It.IsAny<UpdateTruckCommand>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(output);
            _Moqs.ITruckRepository.Setup(prop => prop.AddAsync(It.IsAny<Truck>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(It.IsAny<Truck>());

            var result = await _Moqs.UpdateTruckCommandHandler.Handle(command, It.IsAny<CancellationToken>());

            //assert
            result.Should().NotBeNull();
            var message = Constants.UpdateError.ErrorDefault().InvalidFieldsDefault();
            result.Success.Should().BeFalse();
            result.Message.Should().Be(Constants.UpdateError.InvalidFieldsDefault());

        }
        [Theory]
        [InlineData(1, 2022, 2025)]
        [InlineData(2, 2022, 2022)]
        [InlineData(1, 2022, 2024)]
        [InlineData(1, 2022, 2022)]
        [InlineData(2, 2022, 2024)]
        [InlineData(2, 2022, 2030)]
        [InlineData(1, 2022, 2026)]
        [InlineData(2, 2022, 2025)]
        [InlineData(2, 2022, 2026)]
        [InlineData(1, 2022, 2030)]
        public async Task ShouldNotUpdateTruckWithError(int model, int manufactoryYear, int modelyear)
        {
            //arrange
            var request = _fixture.Build<UpdateTruckRequest>()
                .With(x => x.ManufactoryYear, manufactoryYear)
                .With(x => x.ModelYear, modelyear)
                .With(x => x.Model, model)
                .Create();
            var command = request.UpdateRequestToCommand();
            var output = _fixture.Build<UpdateTruckOutput>()
               .With(x => x.Success, false)
               .With(x => x.Message, Constants.UpdateError.SuccessDefault().ErrorDefault())
               .Create();
            //action
            _Moqs.IMediator.Setup(action => action.Send(It.IsAny<UpdateTruckCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(output);

            _Moqs.ITruckRepository.Setup(prop => prop.AddAsync(It.IsAny<Truck>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(It.IsAny<Truck>());

            var result = await _Moqs.UpdateTruckCommandHandler.Handle(command, It.IsAny<CancellationToken>());

            //assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Message.Should().Be(Constants.UpdateError.ErrorDefault());

        }
    }
}


