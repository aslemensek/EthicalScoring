using EthicalScoring.Data.Models;


namespace EthicalScoring.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private TreisTestContext _dbContext;
        private Repository<Institution> _institutions;


        public UnitOfWork(TreisTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Institution> Institutions
        {
            get
            {
                return _institutions ??
                    (_institutions = new Repository<Institution>(_dbContext));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
