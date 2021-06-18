using Bookclub.Shared.Components.ContainerComponents;
using Microsoft.AspNetCore.Components;

namespace Bookclub.Shared.Components
{
    public partial class ContainerComponent : ComponentBase
    {
        [Parameter]
        public ComponentState State { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public string Error { get; set; }

    }
}
