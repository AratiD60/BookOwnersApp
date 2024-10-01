using BookOwnersApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookOwnersApp.Services
{
    public class BookOwnerService : IBookOwnerService
    {
        private string baseApiUrl = "https://digitalcodingtest.bupa.com.au/api/v1/bookowners";
       
        public IEnumerable<BookOwnerDetails> GetAllBookOwners()
        {
            IEnumerable<BookOwnerDetails> bookOwners = new List<BookOwnerDetails>();

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(baseApiUrl);
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var stringResult = result.Content.ReadAsStringAsync().Result;
                    bookOwners = JsonConvert.DeserializeObject<List<BookOwnerDetails>>(stringResult);                  
                }
            }

            return bookOwners;
        }

        public IEnumerable<Book> GetBooksByAdultOwners()
        {
            IEnumerable<Book> books = new List<Book>();
            IEnumerable<BookOwnerDetails> bookOwners = new List<BookOwnerDetails>();

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(baseApiUrl);
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var stringResult = result.Content.ReadAsStringAsync().Result;
                    bookOwners = JsonConvert.DeserializeObject<List<BookOwnerDetails>>(stringResult);
                }
            }
            if (bookOwners.ToList().Count > 0)
            {
                var adultOwnerList = bookOwners.Where(x => x.age >= 18).ToList();
                var bookList = adultOwnerList.SelectMany(y => y.books).ToList();

                books = bookList.OrderBy(x => x.name);
            }
            
            return books;

        }

        public IEnumerable<Book> GetBooksByChildOwners()
        {
            IEnumerable<Book> books = new List<Book>();
            IEnumerable<BookOwnerDetails> bookOwners = new List<BookOwnerDetails>();

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(baseApiUrl);
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var stringResult = result.Content.ReadAsStringAsync().Result;
                    bookOwners = JsonConvert.DeserializeObject<List<BookOwnerDetails>>(stringResult);
                }
            }
            if (bookOwners.ToList().Count > 0)
            {
                var adultOwnerList = bookOwners.Where(x => x.age < 18).ToList();
                var bookList = adultOwnerList.SelectMany(y => y.books).ToList();

                books = bookList.OrderBy(x => x.name);
            }

            return books;

        }

    }
}
