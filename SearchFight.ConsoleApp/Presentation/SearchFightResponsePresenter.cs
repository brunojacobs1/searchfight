using SearchFight.Domain.DTO;
using System.Linq;
using System.Text;

namespace SearchFight.ConsoleApp.Presentation
{
    public class SearchFightResponsePresenter
    {
        public SearchFightResponseViewModel Handle(SearchFightResponseMessage responseMessage)
        {
            var sb = new StringBuilder();
            var results = responseMessage.SearchResults.GroupBy(search => search.SearchTerm)
                .Select(searchGroup => $"{searchGroup.Key}: \n\t{string.Join("\n\t", searchGroup.Select(term => $"{term.SearchEngine}: {term.Results}"))}")
                .ToList();
            foreach (var result in results)
            {
                sb.AppendLine(result);
            }
            foreach (var winnerEngine in responseMessage.EngineWinners)
            {
                sb.AppendLine(winnerEngine.SearchEngine + " winner: " + winnerEngine.SearchTerm);
            }
            sb.AppendLine("Total winner: " + responseMessage.TotalWinner.SearchTerm);

            return new SearchFightResponseViewModel(sb.ToString());
        }
    }
}
