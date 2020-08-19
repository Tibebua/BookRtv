using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRtv.Data.Specification
{
    public class SearchParam
    {
        private string _search;

        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}
