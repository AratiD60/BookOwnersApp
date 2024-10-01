

using BookOwnersApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookOwnersApp.Services
{
    public interface IBookOwnerService
    {
        IEnumerable<BookOwnerDetails> GetAllBookOwners();
        IEnumerable<Book> GetBooksByAdultOwners();
        IEnumerable<Book> GetBooksByChildOwners();

    }
}
