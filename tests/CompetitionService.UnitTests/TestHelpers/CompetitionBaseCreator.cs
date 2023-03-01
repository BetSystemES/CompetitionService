using CompetitionService.Grpc;
using FizzWare.NBuilder;
using Google.Protobuf.WellKnownTypes;

namespace CompetitionService.UnitTests.TestHelpers
{
    public static class CompetitionBaseCreator
    {
        private static readonly List<CompetitionType> _validCompetitionTypes = new List<CompetitionType>()
        {
            CompetitionType.Esportcs,
            CompetitionType.Esportdota2,
            CompetitionType.Football,
        };

        private static readonly List<CompetitionStatusType> _validCompetitionStatusTypes = new List<CompetitionStatusType>()
        {
            CompetitionStatusType.Live,
            CompetitionStatusType.Waiting,
            CompetitionStatusType.Ended,
        };

        public static CompetitionBase CreateValid()
        {
            var competitionBase = Builder<CompetitionBase>
                .CreateNew()
                .With(x => x.Id = Guid.NewGuid().ToString())
                .With(x => x.StartTime = Timestamp.FromDateTime(DateTime.UtcNow))
                .With(x => x.StatusType = Pick<CompetitionStatusType>.RandomItemFrom(_validCompetitionStatusTypes))
                .With(x => x.Type = Pick<CompetitionType>.RandomItemFrom(_validCompetitionTypes))
                .Build();

            competitionBase.CoefficientGroups.AddRange(CoefficientGroupCreator.CreateValidRange());

            return competitionBase;
        }
    }
}
