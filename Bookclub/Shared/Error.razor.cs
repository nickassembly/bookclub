using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Shared
{
    public partial class Error
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public void ProcessError(Exception ex)
        {
            // TODO: Add table in DB to handle logs. Http client used to call method and have errors logged
            // TODO: Wire up logger in Program.cs
            // TODO: Blazored.Toast library not showing error toasts...
            _toastService.ShowError("Error, something has gone wrong. Contact Support");
            _logger.LogError(ex, "");
        }
    }
}
