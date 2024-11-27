namespace Personal_Library.Entities
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public GenreType Genre { get; set; }

        public enum GenreType
        {

            Fantasy = 1,
            ScienceFiction = 2,
            Biography = 3
        }

        public ICollection<Transactions> Transactions { get; set; }
    }


}
