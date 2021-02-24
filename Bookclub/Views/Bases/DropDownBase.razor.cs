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

        [Parameter]
        public EventCallback<TEnum> ValueChanged { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        public void SetValue(TEnum value) => this.Value = value;

        private Task OnValueChanged(ChangeEventArgs changeEventArgs)
        {
            this.Value = (TEnum) Enum.Parse(typeof(TEnum), changeEventArgs.Value.ToString());

            return ValueChanged.InvokeAsync(this.Value);

        }
        public void Disable()
        {
            this.IsDisabled = true;
            InvokeAsync(StateHasChanged);
        }

        public void Enable()
        {
            this.IsDisabled = false;
            InvokeAsync(StateHasChanged);
        }

    }
}
