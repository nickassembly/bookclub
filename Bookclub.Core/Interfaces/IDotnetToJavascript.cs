using System.Threading.Tasks;

namespace Bookclub.Core.Interfaces
{ 
    public interface IDotnetToJavascript
    {
        Task PrintAsync(int counter);

        Task PrintFormattedMessage();
    }
}