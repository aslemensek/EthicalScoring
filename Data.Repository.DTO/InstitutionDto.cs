using System.ComponentModel.DataAnnotations;


namespace EthicalScoring.Data.Repository.DTO
{
    public class InstitutionDto
    {
        private decimal _totalScoreAsPercentage;

        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public decimal TotalScoreAsPercentage {
            get { return _totalScoreAsPercentage; }
            set { _totalScoreAsPercentage = decimal.Round(value, 2);  }
        }
    }
}




