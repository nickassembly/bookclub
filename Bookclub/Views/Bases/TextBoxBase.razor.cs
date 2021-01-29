using Microsoft.AspNetCore.Components;

namespace Bookclub.Views.Bases
{
    public partial class TextBoxBase
    {
        [Parameter]
        public string Value { get; set; }

        public void SetValue(string value) =>
            this.Value = value;
    }

}
