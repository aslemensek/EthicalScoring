using EthicalScoring.Data.Models;
using EthicalScoring.Data.Repository.DTO;
using System.Collections.Generic;

namespace EthicalScoring.Data.Repository
{
    public interface IInstitutionRepository : IGenericRepository<Institution>
    {
        InstitutionDto GetByID(int id);
        List<InstitutionDto> GetAll();
        void Add(InstitutionDto institution);
        void Update(InstitutionDto institution);
        void Delete(InstitutionDto institution);
    }
}


