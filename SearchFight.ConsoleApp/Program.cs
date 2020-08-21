using SearchFight.ConsoleApp.Presentation;
using SearchFight.Domain.DTO;
using SearchFight.Domain.UseCases;
using SearchFight.Infraestructure.Repository;
using System;
using System.Threading.Tasks;

namespace SearchFight.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: searchfight.exe <search-term-1> <search-term-2> ... <search-term-N>");
            }

            var request = new SearchFightRequestMessage(args);

            var useCase = new SearchFightInteractor(new SearchRepository());
            
            Task.Run(async () =>
            {
                var results = await useCase.Handle(request);
                var response = new SearchFightResponsePresenter();
                var messageToShow = response.Handle(results);
                Console.WriteLine(messageToShow.ResultMessage);
            }).GetAwaiter().GetResult();
            
        }
    }
}
