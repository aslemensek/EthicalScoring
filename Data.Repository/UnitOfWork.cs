using EthicalScoring.Data.Models;


namespace EthicalScoring.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private TreisTestContext _dbContext;
        private IInstitutionRepository _institutions;
        private IEsgCriteriaRepository _criteria;
        private IEsgCriteriaScoreRepository _criteriaScores;
        private IEsgScoreRepository _scores;

        public UnitOfWork(TreisTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IInstitutionRepository Institutions
        {
            get
            {
                return _institutions ??
                    (_institutions = new InstitutionRepository(_dbContext));
            }
        }

        public IEsgCriteriaRepository Criteria
        {
            get
            {
                return _criteria ??
                    (_criteria = new EsgCriteriaRepository(_dbContext));
            }
        }

        public IEsgCriteriaScoreRepository CriteriaScores
        {
            get
            {
                return _criteriaScores ??
                    (_criteriaScores = new EsgCriteriaScoreRepository(_dbContext));
            }
        }

        public IEsgScoreRepository Scores
        {
            get
            {
                return _scores ??
                    (_scores = new EsgScoreRepository(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
