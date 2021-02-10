using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Views.Bases
{
    public partial class DatePickerBase
    {
        [Parameter]
        public DateTimeOffset Value { get; set; }

        public void SetValue(DateTimeOffset value) => this.Value = value;
    }
}
