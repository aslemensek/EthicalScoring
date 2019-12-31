using EthicalScoring.Data.Models;
using EthicalScoring.Data.Repository.DTO;
using System.Collections.Generic;

namespace EthicalScoring.Data.Repository
{
    public interface IInstitutionRepository : IGenericRepository<Institution>
    {
        List<InstitutionDto> GetInstitutions();
    }
}


