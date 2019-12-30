using EthicalScoring.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EthicalScoring.Data.Repository
{
    public class InstitutionRepository : GenericRepository<Institution>, IInstitutionRepository
    {
        public InstitutionRepository(TreisTestContext context): base(context)
        {
        }
        public decimal GetTotalScore() {
            return 100;
        }
    }
}
