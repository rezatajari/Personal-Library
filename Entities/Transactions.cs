using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Library.Entities
{
    internal class Transactions
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
    }
}
