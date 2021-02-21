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

        [Parameter]
        public EventCallback<DateTimeOffset> ValueChanged { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        public async Task SetValue(DateTimeOffset value)
        {
            this.Value = value;
            await ValueChanged.InvokeAsync(this.Value);
        }

        private Task OnValueChanged(ChangeEventArgs changeEventArgs)
        {
            this.Value =  DateTimeOffset.Parse(changeEventArgs.Value.ToString());

            return ValueChanged.InvokeAsync(this.Value);
        }
        public void Disable() => this.IsDisabled = true;
        public void Enable() => this.IsDisabled = false;

    }
}
