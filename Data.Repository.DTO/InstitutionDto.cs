using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthicalScoring.Data.Repository.DTO
{
    public class InstitutionDto
    {
        private decimal _totalScoreAsPercentage;

        public int InstitutionId { get; set; }
        public string InstitutionName { get; set; }
        public decimal TotalScoreAsPercentage {
            get { return _totalScoreAsPercentage; }
            set { _totalScoreAsPercentage = decimal.Round(value, 2);  }
        }
    }
}




