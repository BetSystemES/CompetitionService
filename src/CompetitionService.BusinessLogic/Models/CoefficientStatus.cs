using CompetitionService.BusinessLogic.Models.Enums;

namespace CompetitionService.BusinessLogic.Models
{
    public class CoefficientStatus
    {
        public Guid CoefficientId { get; set; }

        public CoefficientOutcomeType OutcomeType { get; set; }
    }
}
