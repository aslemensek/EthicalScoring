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

            List<InstitutionDto> institutionsWithScorecards = context.Institution
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



            // Include newly created institutions where there is no scorecard created yet
            List<InstitutionDto> institutionsWithNoScoreCard = context.Institution
                .Where(institution => !context.EsgCriteriaScore.Any(esgCriteriaScores => esgCriteriaScores.InstitutionId == institution.InstitutionId))
                .Select(institution => new InstitutionDto
                {
                    InstitutionId = institution.InstitutionId,
                    InstitutionName = institution.InstitutionName,
                    TotalScoreAsPercentage = (decimal)0
                })

            .ToList();


            List<InstitutionDto> institutions = new List<InstitutionDto>();
            institutions.AddRange(institutionsWithScorecards);
            institutions.AddRange(institutionsWithNoScoreCard);

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
