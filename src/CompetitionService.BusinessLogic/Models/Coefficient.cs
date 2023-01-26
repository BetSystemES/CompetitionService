﻿using CompetitionService.BusinessLogic.Enums;

namespace CompetitionService.BusinessLogic.Models
{
    public class Coefficient
    {
        public Guid Id { get; set; }

        public Guid CoefficientGroupIds { get; set; }

        public string Description { get; set; }

        public double Rate { get; set; }

        public CoefficientStatusType StatusType { get; set; }

        public double Amount { get; set; }

        public double Probability { get; set; }
    }
}