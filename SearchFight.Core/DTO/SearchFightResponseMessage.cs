using SearchFight.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Domain.DTO
{
    public class SearchFightResponseMessage
    {
        public IList<Search> SearchResults { get; private set; }
        public IList<WinnerEngine> EngineWinners { get; private set; } 
        public Search TotalWinner { get; private set; }

        public SearchFightResponseMessage(IList<Search> searchResults, IList<WinnerEngine> engineWinners,
            Search totalWinner)
        {
            SearchResults = searchResults;
            EngineWinners = engineWinners;
            TotalWinner = totalWinner;
        }
    }
}
