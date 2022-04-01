using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Components
{
    public partial  class Ponuda : ComponentBase
    {
        [Parameter]
        public string OpportunityId { get; set; }

    }
}
