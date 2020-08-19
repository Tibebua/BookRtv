using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRtv.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Status { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
