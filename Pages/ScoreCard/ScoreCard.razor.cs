using EthicalScoring.Data.Repository;
using EthicalScoring.Data.Repository.DTO;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace EthicalScoring.Pages
{
    public class ScorecardUpdateBase : ComponentBase
    {
        [Inject] UnitOfWork UnitOfWork { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        [Parameter] public string id { get; set; }
        protected List<ScorecardDto> scorecardDtos;

        protected override void OnInitialized()
        {
            scorecardDtos = UnitOfWork.Institutions.GetScoreCard(int.Parse(id));
        }

        protected void UpdateScorecard()
        {
            if (scorecardDtos != null)
            {
                //UnitOfWork.Institutions.Update(scorecardDtos);
                //UnitOfWork.Commit();
                //NavigationManager.NavigateTo("/");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/");
        }

    }
}
