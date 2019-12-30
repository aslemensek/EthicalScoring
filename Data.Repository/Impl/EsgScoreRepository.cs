using EthicalScoring.Data.Models;


namespace EthicalScoring.Data.Repository
{
    public class EsgScoreRepository : GenericRepository<EsgScore>, IEsgScoreRepository
    {
        public EsgScoreRepository(TreisTestContext context) : base(context)
        {
        }
    }
}

