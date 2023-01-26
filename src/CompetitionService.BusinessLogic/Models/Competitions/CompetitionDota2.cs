﻿namespace CompetitionService.BusinessLogic.Models.Competitions
{
    public class CompetitionDota2 : CompetitionBase
    {
        public CompetitionDota2()
        {
        }

        public Guid Id { get; set; }

        public Guid CompetitionBaseId { get; set; }

        public Guid Team1Id { get; set; }

        public Guid Team2Id { get; set; }

        public int Team1KillAmount { get; set; }

        public int Team2KillAmount { get; set; }

        public DateTime TotalTime { get; set; }
    }
}
