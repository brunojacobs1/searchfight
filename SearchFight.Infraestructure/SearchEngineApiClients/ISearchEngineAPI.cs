using System.Threading.Tasks;

namespace SearchFight.Infraestructure.SearchEngineAPIs
{
    /// <summary>
    /// Represents a given search engine api.
    /// </summary>
    public interface ISearchEngineAPI
    {
        /// <summary>
        /// Concrete search engine name.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Get the total number of results from an specific search engine query.
        /// </summary>
        /// <param name="searchTerm">The term to query about.</param>
        /// <returns>Number of results for the given query.</returns>
        Task<long> GetAmountOfResults(string searchTerm);
    }
}
