using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<GoogleApiResponse> GetBooks(Book book);
        Task<GoogleApiResponse> GetBooksByPagination(BookByPagination pagination);
    }
}
