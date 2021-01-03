using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Views.Bases
{
    public partial class TextBoxBase
    {
        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public string PlaceHolder { get; set; }

        public void SetValue(string value) => this.Value = value;
    }
}
