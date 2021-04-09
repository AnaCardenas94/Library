using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Library.Extensions;
using Library.Models;
using Library.Contracts;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _client;

        public BookService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri($"{App.GoogleApiUrl}/")
            };
        }

        public Task<GoogleApiResponse> GetBooks(Book book)
        {
            return _client.Get<GoogleApiResponse>($"volumes?q={book.bookName}");
        }

        public Task<GoogleApiResponse> GetBooksByPagination(BookByPagination pagination)
        {
            return _client.Get<GoogleApiResponse>($"volumes?q={pagination.bookName}&startIndex={pagination.startIndex}&maxResults={pagination.maxResults}");
        }
    }
}
