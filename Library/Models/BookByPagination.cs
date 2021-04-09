namespace Library.Models
{
    public class BookByPagination : Book
    {
        public string startIndex { get; set; }
        public string maxResults { get; set; }
    }
}
