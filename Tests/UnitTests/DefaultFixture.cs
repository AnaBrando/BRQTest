using Application.UseCase.CreateTrunk;
using Domain;
using Domain.Interfaces;
using MediatR;
using Moq;
using Moq.AutoMock;

namespace UnitTests
{
    public class DefaultFixture
    {
        private AutoMocker _mocker;

        public DefaultFixture()
        {
            _mocker = new AutoMocker();
            ITruckRepository = _mocker.GetMock<ITruckRepository>();
            IMediator = _mocker.GetMock<IMediator>();
            CreateTruckCommandHandler = _mocker.CreateInstance<CreateTruckCommandHandler>();
            UpdateTruckCommandHandler = _mocker.CreateInstance<UpdateTruckCommandHandler>();
            DeleteTruckCommandHandler = _mocker.CreateInstance<DeleteTruckCommandHandler>();
        }

        public Mock<ITruckRepository> ITruckRepository { get; set; }
        public Mock<IMediator> IMediator { get; set; }
        public CreateTruckCommandHandler CreateTruckCommandHandler { get; set; }
        public UpdateTruckCommandHandler UpdateTruckCommandHandler { get; set; }
        public DeleteTruckCommandHandler DeleteTruckCommandHandler { get; set; }

    }
}
