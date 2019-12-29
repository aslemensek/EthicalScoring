using System;
using System.Collections.Generic;

namespace EthicalScoring.Data.Models
{
    public partial class EsgCriteriaScore
    {
        public int EsgCriteriaScoreId { get; set; }
        public int InstitutionId { get; set; }
        public int EsgCriteriaId { get; set; }
        public int EsgScoreId { get; set; }

        public virtual EsgCriteria EsgCriteria { get; set; }
        public virtual EsgScore EsgScore { get; set; }
        public virtual Institution Institution { get; set; }
    }
}
