using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Bookclub.Views.Bases
{
    public partial class TextBoxBase : ComponentBase
    {
        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public string Placeholder { get; set; }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        public void SetValue(string value) =>
            this.Value = value;

        private Task OnValueChanged(ChangeEventArgs changeEventArgs)
        {
            this.Value = changeEventArgs.Value.ToString();

            return ValueChanged.InvokeAsync(this.Value);

        }

    }

}
