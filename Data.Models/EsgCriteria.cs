using System;
using System.Collections.Generic;

namespace EthicalScoring.Data.Models
{
    public partial class EsgCriteria
    {
        public EsgCriteria()
        {
            EsgCriteriaScore = new HashSet<EsgCriteriaScore>();
        }

        public int EsgCriteriaId { get; set; }
        public string CriteriaName { get; set; }
        public string CategoryName { get; set; }
        public decimal WeightAsPercentageOfTotal { get; set; }

        public virtual ICollection<EsgCriteriaScore> EsgCriteriaScore { get; set; }
    }
}
