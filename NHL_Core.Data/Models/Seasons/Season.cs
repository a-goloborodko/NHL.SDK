using NHL.Data.Attributes;
using NHL.Data.Enums;
using NHL.Data.Interfaces;
using System;

namespace NHL.Data.Models
{
    [ObjectAnnotation("data")]
    public class Season: INHLModel
    {
        public SeasonEnum Id { get; set; }
        public int AllStarGameInUse { get; set; }
        public int ConferencesInUse { get; set; }
        public int DivisionsInUse { get; set; }
        public DateTime EndDate { get; set; }
        public int EntryDraftInUse { get; set; }
        public string FormattedSeasonId { get; set; }
        public int MinimumPlayoffMinutesForGoalieStatsLeaders { get; set; }
        public int MinimumRegularGamesForGoalieStatsLeaders { get; set; }
        public int NhlStanleyCupOwner { get; set; }
        public int NumberOfGames { get; set; }
        public int OlympicsParticipation { get; set; }
        public int PointForOTLossInUse { get; set; }
        public DateTime? PreseasonStartdate { get; set; }
        public DateTime RegularSeasonEndDate { get; set; }
        public int RowInUse { get; set; }
        public int SeasonOrdinal { get; set; }
        public DateTime StartDate { get; set; }
        public int SupplementalDraftInUse { get; set; }
        public int TiesInUse { get; set; }
        public int TotalPlayoffGames { get; set; }
        public int TotalRegularSeasonGames { get; set; }
        public int WildcardInUse { get; set; }
    }
}