using System;
using System.Collections.Generic;

namespace EthicalScoring.Data.Models
{
    public partial class EsgScore
    {
        public EsgScore()
        {
            EsgCriteriaScore = new HashSet<EsgCriteriaScore>();
        }

        public int EsgScoreId { get; set; }
        public string Score { get; set; }
        public decimal? ScoreAsPercentage { get; set; }

        public virtual ICollection<EsgCriteriaScore> EsgCriteriaScore { get; set; }
    }
}
