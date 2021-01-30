using Bookclub.Views.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub.Views.Components
{
    public partial class AddBookComponent
    {
        public TextBoxBase TextBox { get; set; }

        public void ButtonClicked()
        {
            string textBoxValue = this.TextBox.Value;

            Console.WriteLine(textBoxValue);
        }
    }
}
