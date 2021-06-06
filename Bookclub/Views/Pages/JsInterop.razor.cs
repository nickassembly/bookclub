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
        //[Inject]
        //private IDotnetToJavascript DotnetToJavascript { get; set; }
        //private int currentCount = 0;

        //[Inject]
        //private AddressProvider AddressProvider { get; set; }

        //private async Task IncrementCount()
        //{
        //    currentCount++;
        //    Console.WriteLine($"Current count: {currentCount}");
        //    await DotnetToJavascript.PrintAsync(currentCount);
        //    await DotnetToJavascript.PrintFormattedMessage();
        //}

        //private async Task CallInstanceMethod()
        //{
        //    await AddressProvider.Register();
        //}

        // Test Gauge component using JS Library installed with NPM
        // above code is generic code used to calls JS directly from C#
        async void OnClick()
        {
            await JSRuntime.InvokeVoidAsync("updateValue", 60);
        }


    }
}
