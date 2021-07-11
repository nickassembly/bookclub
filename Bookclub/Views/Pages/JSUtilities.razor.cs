using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Bookclub.Views.Pages
{
    public partial class JSUtilities
    {
        [Inject]
        public IJSRuntime JSRuntissdsdme { get; set; }
        private IJSObjectReference _jsModule;
        protected override async Task OnInitializedAsync()
        {
            //_jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/main.js");
        }
        public async Task GetBookInfoFromISBN()
        {
            string isbn = "0070123332";
            await _jsModule.InvokeVoidAsync("GetBookInfoFromISBN", new { isbn });
        }
    }
}
