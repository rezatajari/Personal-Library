namespace Personal_Library.Entities
{
    public class Transactions
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType Type { get; set; }

        public enum TransactionType
        {
            Borrow,
            Return
        }

        public Books Book { get; set; }
        public Users User { get; set; }
    }
}
