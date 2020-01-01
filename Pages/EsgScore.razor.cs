using EthicalScoring.Data.Repository;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace EthicalScoring.Pages
{
    public class EsgScoreBase : ComponentBase
    {
        [Inject] UnitOfWork UnitOfWork { get; set; }

        protected IEnumerable<Data.Models.EsgScore> scores;

        protected override void OnInitialized()
        {
            scores = UnitOfWork.Scores.GetAll();
        }
    }
}
