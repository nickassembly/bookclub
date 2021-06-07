using Bookclub.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Views.Pages
{
    partial class JsInterop
    {
        async void OnClick()
        {
            string isbn = "0034556678";
            await JSRuntime.InvokeVoidAsync("getBookInfo", new { isbn });
        }


    }
}
