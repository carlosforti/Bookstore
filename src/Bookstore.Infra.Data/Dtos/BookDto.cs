namespace Bookstore.Infra.Data.Dtos
{
    public class BookDto : BaseDto
    {
        public string Name { get; set; }
        public AuthorDto Author { get; set; }
        public PublisherDto Publisher { get; set; }
        public string Isbn { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
    }
}
