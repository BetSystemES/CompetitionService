using FizzWare.NBuilder;
using FluentAssertions;
using Moq;

using CompetitionService.BusinessLogic.Contracts.DataAccess;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Providers;
using CompetitionService.BusinessLogic.Contracts.DataAccess.Repositories;
using CompetitionService.BusinessLogic.Contracts.Services;
using CompetitionService.BusinessLogic.Entities;
using CompetitionService.BusinessLogic.Services;

namespace CompetitionService.UnitTests.BusinessLogic
{
    public class CoefficientServiceTests
    {
        private static readonly CancellationToken _ct = CancellationToken.None;

        private readonly ICoefficientService _coefficientService;

        private readonly Mock<ICoefficientProvider> _mockCoefficientProvider;
        private readonly Mock<ICoefficientRepository> _mockCoefficientRepository;
        private readonly Mock<IDataContext> _mockDataContext;

        public CoefficientServiceTests()
        {
            _mockCoefficientProvider = new();
            _mockCoefficientRepository = new();
            _mockDataContext = new();

            _coefficientService = new CoefficientService(
                _mockCoefficientProvider.Object,
                _mockCoefficientRepository.Object,
                _mockDataContext.Object);
        }

        [Fact]
        public async Task DepositToCoefficientById_Should_Return_Rate()
        {
            // Arrange
            var coefficient = Builder<Coefficient>
                .CreateNew()
                .With(x => x.Rate = 1.1)
                .Build();

            var expectedRate = coefficient.Rate;

            var id = Guid.Empty;
            var amount = int.MaxValue;

            _mockCoefficientProvider.Setup(_ => _.GetById(
                It.IsAny<Guid>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(coefficient);

            // Act
            var actualRate = await _coefficientService.DepositToCoefficientById(id, amount, _ct);

            // Assert
            actualRate.Should()
                .Be(expectedRate);

            _mockDataContext.Verify(_ => _.SaveChanges(It.IsAny<CancellationToken>()),
                Times.Once);

            _mockCoefficientRepository.Verify(_ => _.Update(
                It.IsAny<Coefficient>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}
