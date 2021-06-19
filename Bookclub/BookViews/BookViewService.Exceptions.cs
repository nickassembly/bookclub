using Bookclub.Core.DomainAggregates;
using System.Threading.Tasks;

namespace Bookclub.Services.BookViews
{
    public partial class BookViewService
    {
        private delegate ValueTask<BookView> ReturningBookViewFunction();

        private async ValueTask<BookView> TryCatch(ReturningBookViewFunction returningBookViewFunction)
        {
            try
            {
                return await returningBookViewFunction();
            }
            catch
            {
                return null;
                // TODO: Define proper exceptions here
            }
        }

    }
}
