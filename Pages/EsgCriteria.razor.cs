using EthicalScoring.Data.Repository;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace EthicalScoring.Pages
{
    public class EsgCriteriaBase : ComponentBase
    {
        [Inject] UnitOfWork UnitOfWork { get; set; }

        protected IEnumerable<Data.Models.EsgCriteria> criteria;

        protected override void OnInitialized()
        {
            criteria = UnitOfWork.Criteria.GetAll();
        }
    }
}
