namespace Ef7BulkActions.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public int Year { get; set; }
    }
}
