using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Bookclub.Views.Pages
{
    partial class JsInterop
    {
        async void OnClick()
        {
            string isbn = "0735619670";
            await JSRuntime.InvokeVoidAsync("getBookInfo", new { isbn });
            await DoSomeStuff(isbn);
        }

        [JSInvokable] // csharp method getting called from JS
        async Task DoSomeStuff(string isbn)
        {
            await JSRuntime.InvokeVoidAsync("ReturnData", isbn);
        }

    }
}
