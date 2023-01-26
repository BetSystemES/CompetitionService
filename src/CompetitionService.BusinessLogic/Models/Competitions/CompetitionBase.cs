using CompetitionService.BusinessLogic.Enums;

namespace CompetitionService.BusinessLogic.Models.Competitions
{
    public class CompetitionBase
    {
        public CompetitionBase()
        {
            CoefficientGroupIds = Array.Empty<Guid>();
        }

        public Guid Id { get; set; }

        public CompetitionStatusType StatusType { get; set; }

        public CompetitionType Type { get; set; }

        public DateTime StartTime { get; set; }

        public Guid[] CoefficientGroupIds { get; set; }
    }
}
