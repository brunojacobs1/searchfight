using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Domain.Entities
{
    public class Search
    {
        public string SearchEngine { get; set; }
        public string SearchTerm { get; set; }
        public long Results { get; set; }


    }
}
