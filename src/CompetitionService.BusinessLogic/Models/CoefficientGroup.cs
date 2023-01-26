using CompetitionService.BusinessLogic.Enums;

namespace CompetitionService.BusinessLogic.Models
{
    public class CoefficientGroup
    {
        public CoefficientGroup()
        {
            CoefficientsIds = Array.Empty<Guid>();
        }

        public Guid Id { get; set; }

        public Guid CompetitionBaseId { get; set; }

        public string Name { get; set; }

        public CoefficientGroupType Type { get; set; }

        public Guid[] CoefficientsIds { get; set; }
    }
}
