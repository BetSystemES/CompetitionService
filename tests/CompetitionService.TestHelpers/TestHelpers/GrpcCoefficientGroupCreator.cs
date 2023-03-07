using CompetitionService.Grpc;
using FizzWare.NBuilder;

namespace CompetitionService.TestHelpers.TestHelpers
{
    /// <summary>
    /// Create <seealso cref="CoefficientGroup"/>
    /// </summary>
    public static class GrpcCoefficientGroupCreator
    {
        private static readonly List<CoefficientGroupType> _validCoefficientGroupType = new List<CoefficientGroupType>()
        {
            CoefficientGroupType.OneWinner,
            CoefficientGroupType.TwoWinners
        };

        public static IEnumerable<CoefficientGroup> CreateValidRange(int size = 2)
        {
            var coefficientGroups = new List<CoefficientGroup>();
            while (size is not 0)
            {
                coefficientGroups.Add(CreateValid());
                size--;
            }

            return coefficientGroups;
        }

        public static CoefficientGroup CreateValid()
        {
            var coefficientGroup = Builder<CoefficientGroup>
                .CreateNew()
                .With(x => x.Id = Guid.NewGuid().ToString())
                .With(x => x.Name = "Name")
                .With(x => x.Type = Pick<CoefficientGroupType>.RandomItemFrom(_validCoefficientGroupType))
                .Build();

            coefficientGroup.Coefficients.AddRange(GrpcCoefficientCreator.CreateValidRange());

            return coefficientGroup;
        }
    }
}
