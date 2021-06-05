using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Services
{
    public class DotnetToJavascript : IDotnetToJavascript
    {
        private readonly IJSRuntime _iJSRuntime;
        private readonly ILogger<DotnetToJavascript> _logger;
        public DotnetToJavascript(IJSRuntime iJSRuntime, ILogger<DotnetToJavascript> logger)
        {
            _iJSRuntime = iJSRuntime;
            _logger = logger;
        }

        public async Task PrintAsync(int counter)
        {
            await _iJSRuntime.InvokeVoidAsync("logUser", counter);
        }

        public async Task PrintFormattedMessage()
        {
            var message = await _iJSRuntime.InvokeAsync<string>("getFormattedMessage");
            _logger.LogInformation(message);
        }
    }
}
