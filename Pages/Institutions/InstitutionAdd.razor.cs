using EthicalScoring.Data.Repository;
using EthicalScoring.Data.Repository.DTO;
using Microsoft.AspNetCore.Components;

namespace EthicalScoring.Pages
{
    public class InstitutionsAddBase : ComponentBase
    {
        [Inject] UnitOfWork UnitOfWork { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

    protected InstitutionDto institutionDto;

        protected override void OnInitialized()
        {
            institutionDto = new InstitutionDto();
        }

        protected void CreateInstitution()
        {
            if (institutionDto != null)
            {
                UnitOfWork.Institutions.Add(institutionDto);
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
