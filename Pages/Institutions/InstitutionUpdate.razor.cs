using EthicalScoring.Data.Repository;
using EthicalScoring.Data.Repository.DTO;
using Microsoft.AspNetCore.Components;

namespace EthicalScoring.Pages
{
    public class InstitutionsUpdateBase : ComponentBase
    {
        [Inject] UnitOfWork UnitOfWork { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        [Parameter] public string id { get; set; }
        protected InstitutionDto institutionDto;

        protected override void OnInitialized()
        {
            institutionDto = UnitOfWork.Institutions.GetByID(int.Parse(id));
        }

        protected void UpdateInstitution()
        {
            if (institutionDto != null)
            {
                UnitOfWork.Institutions.Update(institutionDto);
                UnitOfWork.Commit();
                NavigationManager.NavigateTo("/");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/");
        }

    }
}
