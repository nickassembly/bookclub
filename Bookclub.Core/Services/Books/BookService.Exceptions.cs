//using Bookclub.Core.DomainAggregates;
//using System.Threading.Tasks;

//namespace Bookclub.Services.Books
//{
//    public partial class BookService
//    {
//        private delegate ValueTask<Book> ReturningBookFunction();

//        private async ValueTask<Book> TryCatch(ReturningBookFunction returningBookFunction)
//        {
//            try
//            {
//                return await returningBookFunction();
//            }
//            catch
//            {
//                return null;
//                // TODO: Define exceptions to catch here.
//            }
//        }

      

//    }
//}
