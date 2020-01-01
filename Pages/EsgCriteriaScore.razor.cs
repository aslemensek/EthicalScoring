using EthicalScoring.Data.Repository;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace EthicalScoring.Pages
{
    public class EsgCriteriaScoreBase : ComponentBase
    {
        [Inject] UnitOfWork UnitOfWork { get; set; }
        protected IEnumerable<Data.Models.EsgCriteriaScore> criteriascores;

        protected override void OnInitialized()
        {
            criteriascores = UnitOfWork.CriteriaScores.GetAll();
        }
    }
}
