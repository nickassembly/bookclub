using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Bookclub.Views.Pages
{
    partial class JsInterop
    {
        // TODO: Integrate Isbn Library and Data fetching
        async void OnClick()
        {
            string isbn = "0034556678";
            await JSRuntime.InvokeVoidAsync("getBookInfo", new { isbn });
            await DoSomeStuff(isbn);
        }

        [JSInvokable] // can be called from javascript
        async Task DoSomeStuff(string isbn)
        {
            await JSRuntime.InvokeVoidAsync("ReturnData", isbn);
        }

    }
}
