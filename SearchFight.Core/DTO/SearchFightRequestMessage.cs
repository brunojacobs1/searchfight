using SearchFight.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Domain.DTO
{
    public class SearchFightRequestMessage : IRequest<SearchFightResponseMessage>
    {
        public IList<string> SearchTerms { get; private set; }
        public SearchFightRequestMessage(IList<string> searchTerms)
        {
            SearchTerms = searchTerms;
        }
    }
}
