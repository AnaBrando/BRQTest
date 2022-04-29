using Application.UseCase.Queries;
using Application.UseCase.Queries.GetAllTruck;
using AutoFixture;
using Domain;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.GetAllTrucksTests
{
    public class GetAllTrucksTests
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
        [InlineData(1, 2022, 2028)]
        [InlineData(2, 2022, 2026)]
        [InlineData(2, 2022, 2029)]
        [InlineData(1, 2022, 2029)]
        public async Task ShouldReturnAllTrucksWithSuccess(int model, int manufactoryYear, int modelYear)
        {
            var output = new List<Truck>();
            output.Add(new Truck(manufactoryYear, (Model)model, modelYear));
            _Moqs.ITruckRepository.Setup(prop => prop.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(output);
            var result = await _Moqs.TrunkQueryHandler.Handle(It.IsAny<ListTrucksQuery>(), It.IsAny<CancellationToken>());
            result.Should().NotBeNull();
            result.Trucks.Should().HaveCountGreaterThanOrEqualTo(1);
            result.Success.Should().BeTrue();
        }
        [Theory]
        [InlineData(1, 2022, 2025)]
        [InlineData(2, 2022, 2022)]
        [InlineData(1, 2022, 2024)]
        [InlineData(1, 2022, 2022)]
        [InlineData(2, 2022, 2024)]
        [InlineData(2, 2022, 2030)]
        [InlineData(1, 2022, 2028)]
        [InlineData(2, 2022, 2026)]
        [InlineData(2, 2022, 2029)]
        [InlineData(1, 2022, 2029)]
        public async Task ShouldReturnAllTrucksWithNoResult(int model, int manufactoryYear, int modelYear)
        {
            var output = new List<Truck>();
            output.Add(new Truck(manufactoryYear, (Model)model, modelYear));
            _Moqs.ITruckRepository.Setup(prop => prop.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(It.IsAny<List<Truck>>());
            var result = await _Moqs.TrunkQueryHandler.Handle(It.IsAny<ListTrucksQuery>(), It.IsAny<CancellationToken>());
            result.Should().NotBeNull();
            result.Trucks.Should().HaveCount(0);
            result.Success.Should().BeFalse();
        }
    }
}
