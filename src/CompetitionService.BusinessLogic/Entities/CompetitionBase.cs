﻿using CompetitionService.BusinessLogic.Models.Enums;

namespace CompetitionService.BusinessLogic.Entities
{
    /// <summary>
    /// Competition base entity
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
