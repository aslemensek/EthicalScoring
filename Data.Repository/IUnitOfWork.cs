using EthicalScoring.Data.Models;

namespace EthicalScoring.Data.Repository
{
    public interface IUnitOfWork
    {
        IInstitutionRepository Institutions { get; }
        IEsgCriteriaRepository Criteria { get; }
        IEsgCriteriaScoreRepository CriteriaScores { get; }
        IEsgScoreRepository Scores { get; }
        void Commit();
    }
}
