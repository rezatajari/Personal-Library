using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Library.Entities
{
    internal class Books
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public GenreType Genre { get; set; }

        public enum GenreType
        {

            Fantasy = 1,
            ScienceFiction = 2,
            Biography = 3
        }
    }


}
