using EthicalScoring.Data.Models;
using EthicalScoring.Data.Repository.DTO;
using System.Collections.Generic;
using System.Linq;

namespace EthicalScoring.Data.Repository
{
    public class InstitutionRepository : GenericRepository<Institution>, IInstitutionRepository
    {
        public InstitutionRepository(TreisTestContext context) : base(context)
        {
        }

        public List<InstitutionDto> GetAll()
        {
            //var institutions = context.Institution
            //    .Include(institution => institution.EsgCriteriaScore)
            //        .ThenInclude(esgCriteriaScore => esgCriteriaScore.EsgScore.ScoreAsPercentage)
            //        .Select(m => new InstitutionDto { 
            //            InstitutionId = m.InstitutionId, 
            //            InstitutionName = m.InstitutionName, 
            //            TotalScore = m.EsgCriteriaScore.
            //        })
            //    ;

            var institutions = context.Institution
                .Join(context.EsgCriteriaScore,
                    a => a.InstitutionId, b => b.InstitutionId, (a, b) => new
                    {
                        a.InstitutionId,
                        a.InstitutionName,
                        b.EsgScoreId,
                        b.EsgCriteriaId
                    })
                .Join(context.EsgScore,
                    a => a.EsgScoreId, b => b.EsgScoreId, (a, b) => new
                    {
                        a.InstitutionId,
                        a.InstitutionName,
                        a.EsgScoreId,
                        a.EsgCriteriaId,
                        ScoreAsPercentage = (decimal?)b.ScoreAsPercentage
                    })
                .Join(context.EsgCriteria,
                    a => a.EsgCriteriaId, b => b.EsgCriteriaId, (a, b) => new
                    {
                        a.InstitutionId,
                        a.InstitutionName,
                        a.EsgScoreId,
                        a.EsgCriteriaId,
                        a.ScoreAsPercentage,
                        b.WeightAsPercentageOfTotal
                    })
                //.ToList() //would greatly impact performance at all levels
                .GroupBy(m => m.InstitutionId)
                .Select(m => new InstitutionDto
                {
                    InstitutionId = m.Key, //Workaround as .First() not supported for anonymous types
                    InstitutionName = m.Max(a => a.InstitutionName),
                    TotalScoreAsPercentage = m.Sum(s => (s.ScoreAsPercentage ?? 0) * s.WeightAsPercentageOfTotal * 100)
                })
                .ToList();
                

            return institutions;
        }

        public void Add(InstitutionDto institutionDto) {
            Institution institution = new Institution()
            {
                InstitutionName = institutionDto.InstitutionName
            };

            context.Institution.Add(institution);
        }
    }
}
