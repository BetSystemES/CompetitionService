using CompetitionService.BusinessLogic.Enums;
using CompetitionService.BusinessLogic.Models.Competitions;

namespace CompetitionService.BusinessLogic.Models
{
    // TODO: Change file location to CompetitionService.DataAccess.Entities
    public class CoefficientGroup
    {
        public CoefficientGroup()
        {
        }

        public Guid Id { get; set; }

        public Guid CompetitionBaseId { get; set; }

        // TODO: typo competitionBase. Should be CompetitionBase
        public CompetitionBase competitionBase { get; set; }

        public string Name { get; set; }

        public CoefficientGroupType Type { get; set; }

        public List<Coefficient> Coefficients { get; set; }
    }
}
