using CompetitionService.Grpc;
using FizzWare.NBuilder;

namespace CompetitionService.UnitTests.TestHelpers
{
    /// <summary>
    /// Create <seealso cref="Coefficient"/>
    /// </summary>
    public static class CoefficientCreator
    {
        private static readonly List<CoefficientStatusType> _validCoefficientStatusTypes = new List<CoefficientStatusType>()
        {
            CoefficientStatusType.Active,
            CoefficientStatusType.Completed,
            CoefficientStatusType.Blocked

        };

        public static IEnumerable<Coefficient> CreateValidRange(int size = 2)
        {
            var coefficients = Builder<Coefficient>
                .CreateListOfSize(size)
                .All()
                .With(x => x.Description = "Description")
                .With(x => x.Id = Guid.NewGuid().ToString())
                .With(x => x.Rate = 1.53)
                .With(x => x.Amount = 100.10)
                .With(x => x.Probability = 10.10)
                .With(x => x.StatusType = Pick<CoefficientStatusType>.RandomItemFrom(_validCoefficientStatusTypes))
                .Build();

            return coefficients;
        }
    }
}
