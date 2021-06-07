using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Views.Pages
{
    public class AddressProvider : IDisposable
    {
        private DotNetObjectReference<AddressProvider> _objectReference;
        private readonly IJSRuntime _iJSRuntime;
        public AddressProvider(IJSRuntime iJSRuntime)
        {
            _iJSRuntime = iJSRuntime;
        }

        public async Task Register()
        {
            _objectReference = DotNetObjectReference.Create(this);
            await _iJSRuntime.InvokeVoidAsync("invokeDotnetInstanceFunction", _objectReference);
        }

        // calling js instance method
        [JSInvokable]
        public string GetAddress()
        {
            return "123 Main Street";
        }

        public void Dispose()
        {
            _objectReference.Dispose();
        }
    }
}
