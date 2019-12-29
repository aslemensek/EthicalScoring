using System;
using System.Collections.Generic;

namespace EthicalScoring.Data.Models
{
    public partial class Institution
    {
        public Institution()
        {
            EsgCriteriaScore = new HashSet<EsgCriteriaScore>();
        }

        public int InstitutionId { get; set; }
        public string InstitutionName { get; set; }

        public virtual ICollection<EsgCriteriaScore> EsgCriteriaScore { get; set; }
    }
}
