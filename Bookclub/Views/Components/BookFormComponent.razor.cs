using Bookclub.Models.Basics;
using Bookclub.Views.Bases;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Views.Components
{
    public partial class BookFormComponent : ComponentBase
    {
        public TextBoxBase BookTextBox { get; set; }

        public ComponentState State { get; set; }

        protected override void OnInitialized()
        {
            this.State = ComponentState.Content;
        }
    }
}
