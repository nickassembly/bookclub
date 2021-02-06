using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Views.Bases
{
    public partial class DropDownBase<TEnum> : ComponentBase
    {
        [Parameter]
        public TEnum Value { get; set; }
    }
}
