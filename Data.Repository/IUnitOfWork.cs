using EthicalScoring.Data.Models;

namespace EthicalScoring.Data.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Institution> Institutions { get; }
        void Commit();
    }
}
