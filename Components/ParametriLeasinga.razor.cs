using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrmExpert.Components
{
    public partial class ParametriLeasinga :  ComponentBase
    {
        public ParametriLeasinga()
        {

        }
        [Parameter]
        public string OpportunityId { get; set; }
    }
}
