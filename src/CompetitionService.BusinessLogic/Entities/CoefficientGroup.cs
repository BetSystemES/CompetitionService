using CompetitionService.BusinessLogic.Models.Enums;

namespace CompetitionService.BusinessLogic.Entities
{
    public class CoefficientGroup
    {
        public CoefficientGroup()
        {
        }

        public Guid Id { get; set; }

        public Guid CompetitionBaseId { get; set; }

        public CompetitionBase CompetitionBase { get; set; }

        public string Name { get; set; }

        public CoefficientGroupType Type { get; set; }

        public List<Coefficient> Coefficients { get; set; }
    }
}
