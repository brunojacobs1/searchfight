
namespace SearchFight.ConsoleApp.Presentation
{
    public class SearchFightResponseViewModel
    {
        public string ResultMessage { get; private set; }
        public SearchFightResponseViewModel(string resultMessage)
        {
            ResultMessage = resultMessage;
        }
    }
}
