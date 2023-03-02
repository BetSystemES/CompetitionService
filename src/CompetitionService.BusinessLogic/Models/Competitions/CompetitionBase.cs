using CompetitionService.BusinessLogic.Enums;

namespace CompetitionService.BusinessLogic.Models.Competitions
{
    // TODO: Change file location to CompetitionService.BusinessLogic.Entities
    /// <summary>
    /// competition base entity
    /// </summary>
    public class CompetitionBase
    {
        public CompetitionBase()
        {
        }

        public Guid Id { get; set; }

        public CompetitionStatusType StatusType { get; set; }

        public CompetitionType Type { get; set; }

        public DateTime StartTime { get; set; }

        public List<CoefficientGroup> CoefficientGroups { get; set; }
    }
}
