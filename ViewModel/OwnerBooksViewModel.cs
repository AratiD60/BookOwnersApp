using BookOwnersApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOwnersApp.ViewModel
{
    public class OwnerBooksViewModel
    {
       public IEnumerable<BookOwnerDetails> BookOwners { get; set; }
    }
}
