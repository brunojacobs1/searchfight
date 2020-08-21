using SearchFight.Domain.Entities;
using SearchFight.Domain.Interfaces;
using SearchFight.Infraestructure.SearchEngineAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Infraestructure.Repository
{
    public class SearchRepository : IRepository
    {
        private readonly IList<ISearchEngineAPI> _searchEngines;

        public SearchRepository()
        {
            _searchEngines = GetImplementations();
        }

        private IList<ISearchEngineAPI> GetImplementations()
        {
            var type = typeof(ISearchEngineAPI);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract)
                .Select(p => Activator.CreateInstance(p) as ISearchEngineAPI).ToList();

            return types;
        }
        public async Task<IList<Search>> GetResults(IList<string> searchTerms)
        {
            IList<Search> searches = new List<Search>();

            foreach (ISearchEngineAPI engine in _searchEngines)
            {
                foreach (string searchTerm in searchTerms)
                {
                    searches.Add(new Search
                    {
                        SearchEngine = engine.Name,
                        SearchTerm = searchTerm,
                        Results = await engine.GetAmountOfResults(searchTerm)
                    });
                }
            }
            return searches;
        }
    }
}
