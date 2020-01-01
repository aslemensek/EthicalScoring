using EthicalScoring.Data.Repository;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace EthicalScoring.Pages
{
    public class InstitutionsBase : ComponentBase
    {
        [Inject] UnitOfWork UnitOfWork { get; set; }

        protected string score_color;
        protected IEnumerable<Data.Repository.DTO.InstitutionDto> institutions;

        protected override void OnInitialized()
        {
            institutions = UnitOfWork.Institutions.GetAll();
        }
    }
}
