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

        protected List<string> scoreList = new List<string>() { "N/A", "0", "1", "2", "3" };

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


        protected void ScoreChanged(ChangeEventArgs e)
        {
            string selectedString = e.Value.ToString();
            //TODO
        }


    }
}
