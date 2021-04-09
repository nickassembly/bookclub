using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Views.Pages
{
    public partial class Index : ComponentBase
    {
        public List<int> Numbers { get; set; } = Enumerable.Range(start: 0, count: 10).ToList();
    }
}
