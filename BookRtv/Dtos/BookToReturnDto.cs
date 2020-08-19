using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRtv.Dtos
{
    public class BookToReturnDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Status { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}
