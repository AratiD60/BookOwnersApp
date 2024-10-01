using System.Collections.Generic;

namespace BookOwnersApp.Models
{
    public class BookOwnerDetails
    {
        public string name { get; set; }
        public int age { get; set; }
        public List<Book> books { get; set; }
    }
}
