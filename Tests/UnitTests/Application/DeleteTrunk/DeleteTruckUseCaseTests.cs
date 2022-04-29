using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Extensions.Mapping;
using Application.UseCase.CreateTrunk;
using AutoFixture;
using Domain;
using FluentAssertions;
using Moq;
using Presentation.Transport;
using Xunit;


namespace UnitTests.DeleteTruckUseCaseTests
{
    public class DeleteTruckUseCaseTests
    {

        private readonly Fixture _fixture = new Fixture();
        private readonly DefaultFixture _Moqs = new DefaultFixture();


        [Theory]
        [InlineData("dee2a32d-7f2f-44a4-ab53-174ab3b55b3e")]
        [InlineData("298c48fa-5284-415c-ba47-0decf18cbc0e")]
        [InlineData("d0289ac3-783e-4fa5-95d9-1ad183eb5be7")]
        [InlineData("db631e07-28f8-4872-9557-9dc8a7038dad")]
        [InlineData("2edfad94-410d-4177-a647-2f7936d6d878")]
        [InlineData("1d811931-c99f-4c7a-bf38-d4688c70910c")]
        [InlineData("2960bd7b-6974-4e51-808b-9e78cd34b94b")]
        [InlineData("4fa5aaa2-e452-4d7f-8810-4d36e99c9c64")]
        [InlineData("91f44fba-dd16-469e-8232-120549be8f0c")]
        [InlineData("793a07f6-4254-4cf5-8746-094607a2774a")]
        [InlineData("98e4a3c1-7014-457d-b4d6-0ef05a63e3f6")]
        [InlineData("8a087a96-4950-47f2-812a-15ec24495e5b")]
        public async Task ShouldDeleteTruckWithSuccess(string id)
        {
            //arrange

            var request = _fixture.Build<DeleteTruckRequest>()
                .With(x => x.Id, id)
                .Create();
            var command = request.DeleteRequestToCommand();
            var output = _fixture.Build<DeleteTruckOutput>()
               .With(x => x.Success, true)
               .With(x => x.Message, Constants.CreateSuccess.SuccessDefault())
               .Create();
            //action
            _Moqs.IMediator.Setup(action => action.Send(It.IsAny<DeleteTruckCommand>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(output);

            _Moqs.ITruckRepository.Setup(prop => prop.DeleteAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(true);

            var result = await _Moqs.DeleteTruckCommandHandler.Handle(command, It.IsAny<CancellationToken>());

            //assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Message.Should().Be(Constants.DeleteSuccess.SuccessDefault());


        }

        [Theory]
        [InlineData("dee2a32d-7f2f-44a4-ab53-174ab3b55b3e")]
        [InlineData("298c48fa-5284-415c-ba47-0decf18cbc0e")]
        [InlineData("d0289ac3-783e-4fa5-95d9-1ad183eb5be7")]
        [InlineData("db631e07-28f8-4872-9557-9dc8a7038dad")]
        [InlineData("2edfad94-410d-4177-a647-2f7936d6d878")]
        [InlineData("1d811931-c99f-4c7a-bf38-d4688c70910c")]
        public async Task ShouldNotDeleteTruckWithError(string id)
        {
            //arrange
            var request = _fixture.Build<DeleteTruckRequest>()
                .With(x => x.Id, id)
                .Create();
            var command = request.DeleteRequestToCommand();
            var output = _fixture.Build<DeleteTruckOutput>()
               .With(x => x.Success, false)
               .With(x => x.Message, Constants.ErrorCreate.SuccessDefault().ErrorDefault())
               .Create();
            //action
            _Moqs.IMediator.Setup(action => action.Send(It.IsAny<DeleteTruckCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(output);

            _Moqs.ITruckRepository.Setup(prop => prop.AddAsync(It.IsAny<Truck>(), It.IsAny<CancellationToken>()))
                  .ReturnsAsync(It.IsAny<Truck>());

            var result = await _Moqs.DeleteTruckCommandHandler.Handle(command, It.IsAny<CancellationToken>());

            //assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Message.Should().Be(Constants.DeleteError.ErrorDefault());


        }
    }
}
