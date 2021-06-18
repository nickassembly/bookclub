using Bookclub.Shared.Colors;
using Microsoft.AspNetCore.Components;

namespace Bookclub.Views.Bases
{
    public partial class LabelBase
    {
        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public Color Color { get; set; }

        public void SetValue(string value)
        {
            this.Value = value;
            InvokeAsync(StateHasChanged);
        }

        public void SetColor(Color color) => this.Color = color;

    }
}
