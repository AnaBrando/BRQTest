using Application.Extensions.Mapping;
using AutoFixture;
using Domain;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Domain
{

    public class TruckUnitTests
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
        public void ShouldCreateTruckWithSuccess(int model, int manufactoryYear, int modelyear)
        {
            //arrange

            var request = _fixture.Build<CreateTruckRequest>()
                .With(x => x.ManufactoryYear, manufactoryYear)
                .With(x => x.ModelYear, modelyear)
                .With(x => x.Model, model)
                .Create();

            var command = request.CreateRequestToCommand();

            var domain = command.CreateTruckCommandToModel();
            domain.Should().NotBeNull();
            domain.Id.Should().NotBeEmpty();
            domain.ManufactoryYear.Should().Be(manufactoryYear);
            domain.ModelYear.Should().Be(modelyear);
            domain.Model.Should().Be((Model)model);
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
        public void ShouldChangeTruckWithUpdate(int model, int manufactoryYear, int modelyear)
        {
            //arrange
            var init = new Truck(2050, Model.FH, 2022);
            var request = _fixture.Build<CreateTruckRequest>()
                .With(x => x.ManufactoryYear, manufactoryYear)
                .With(x => x.ModelYear, modelyear)
                .With(x => x.Model, model)
                .Create();

            var command = request.CreateRequestToCommand();

            var domain = command.CreateTruckCommandToModel();
            init.Update(domain);
            init.Should().NotBeNull();
            init.Id.Should().NotBeEmpty();
            init.ManufactoryYear.Should().Be(domain.ManufactoryYear);
            init.ModelYear.Should().Be(domain.ModelYear);
            init.Model.Should().Be(domain.Model);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void ShouldChangeEnumSuccess(int model)
        {
            //arrange
            var enun = (Model)model;
            enun.Should().Be(model == 1 ? Model.FH : Model.FM);
        }
      
    }
}