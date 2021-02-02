
using Bookclub.Services.BookViews;
using Bookclub.Views.Components;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Bookclub.Tests.Views.AddBookComponents
{
    public partial class AddBookComponentTests : TestContext
    {
        private readonly Mock<IBookViewService> _bookViewServiceMock;
        private IRenderedComponent<AddBookComponent> _addBookComponent;

        public AddBookComponentTests()
        {
            _bookViewServiceMock = new Mock<IBookViewService>();
            this.Services.AddScoped(services => this._bookViewServiceMock.Object);
            this.Services.AddServerSideBlazor();
        }

    }
}
