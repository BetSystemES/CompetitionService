using CompetitionService.BusinessLogic.Models.Enums;

namespace CompetitionService.BusinessLogic.Entities
{
    public class Coefficient
    {
        public Guid Id { get; set; }

        public Guid CoefficientGroupId { get; set; }

        public CoefficientGroup CoefficientGroup { get; set; }

        public string Description { get; set; }

        public double Rate { get; set; }

        public CoefficientStatusType StatusType { get; set; }

        public double Amount { get; set; }

        public double Probability { get; set; }
    }
}
