using SearchFight.Domain.DTO;
using SearchFight.Domain.Entities;
using SearchFight.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFight.Domain.UseCases
{
    public class SearchFightInteractor : IRequestHandler<SearchFightRequestMessage, Task<SearchFightResponseMessage>>
    {
        private readonly IRepository _repository;
        public SearchFightInteractor(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<SearchFightResponseMessage> Handle(SearchFightRequestMessage data)
        {
            //Checks if data is null or empty.
            if (data?.SearchTerms?.Any() != true)
            {
                throw new ArgumentException("The specified data argument is null or empty.", nameof(data));
            }

            static Search MaxTerm(Search s1, Search s2) => s1.Results > s2.Results ? s1 : s2;

            var results = await _repository.GetResults(data.SearchTerms);
            var engineWinners = results.GroupBy((search) => search.SearchEngine,
                    (search) => search, (searchEngine, searches) => new WinnerEngine
                    {
                        SearchEngine = searchEngine,
                        SearchTerm = searches.Aggregate(MaxTerm).SearchTerm
                    }).ToList();
            var totalWinner = results.Aggregate(MaxTerm);

            return new SearchFightResponseMessage(results, engineWinners, totalWinner);
        }
    }
}
