using EthicalScoring.Data.Models;


namespace EthicalScoring.Data.Repository
{
    public class EsgCriteriaRepository : GenericRepository<EsgCriteria>, IEsgCriteriaRepository
    {
        public EsgCriteriaRepository(TreisTestContext context) : base(context)
        {
        }
    }
}



