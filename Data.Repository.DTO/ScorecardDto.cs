using System.ComponentModel.DataAnnotations;

namespace EthicalScoring.Data.Repository.DTO
{
    public class ScorecardDto
    {
        private decimal _scoreAsPercentage;
        public int InstitutionId { get; set; }
        public int CriteriaId { get; set; }
        public string CriteriaName { get; set; }
        public string CategoryName { get; set; }
        public decimal WeightAsPercentageOfTotal { get; set; }
        public int ScoreId { get; set; }
        public string Score { get; set; }
        public decimal ScoreAsPercentage
        {
            get { return _scoreAsPercentage; }
            set { _scoreAsPercentage = decimal.Round(value, 2); }
        }
    }
}
