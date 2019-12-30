using EthicalScoring.Data.Models;


namespace EthicalScoring.Data.Repository
{
    public class EsgCriteriaScoreRepository : GenericRepository<EsgCriteriaScore>, IEsgCriteriaScoreRepository
    {
        public EsgCriteriaScoreRepository(TreisTestContext context) : base(context)
        {
        }
    }
}



