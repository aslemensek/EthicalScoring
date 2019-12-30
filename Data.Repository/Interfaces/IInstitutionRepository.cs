using EthicalScoring.Data.Models;

namespace EthicalScoring.Data.Repository
{
    public interface IInstitutionRepository : IGenericRepository<Institution>
    { 
        decimal GetTotalScore();
    }
}


