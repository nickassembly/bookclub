using Microsoft.JSInterop;

namespace Bookclub.Views.Pages
{
    partial class JsInterop
    {
        // TODO: Integrate Isbn Library and Data fetching
        async void OnClick()
        {
            string isbn = "0034556678";
            await JSRuntime.InvokeVoidAsync("getBookInfo", new { isbn });
        }


    }
}
