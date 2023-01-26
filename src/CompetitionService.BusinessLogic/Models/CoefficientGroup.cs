using CompetitionService.BusinessLogic.Enums;
using CompetitionService.BusinessLogic.Models.Competitions;

namespace CompetitionService.BusinessLogic.Models
{
    public class CoefficientGroup
    {
        public CoefficientGroup()
        {
        }

        public Guid Id { get; set; }

        public Guid CompetitionBaseId { get; set; }

        public CompetitionBase competitionBase { get; set; }

        public string Name { get; set; }

        public CoefficientGroupType Type { get; set; }

        public List<Coefficient> Coefficients { get; set; }
    }
}
