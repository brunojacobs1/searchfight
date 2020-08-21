using SearchFight.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Domain.Interfaces
{
    /// <summary>
    /// Represents an implementation of the repository pattern.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Perform search with a search engine and get the results.
        /// </summary>
        /// <param name="searchTerms">List of terms to search.</param>
        /// <returns>List of Search entities with the total amount of results for the specified search term.</returns>
        Task<IList<Search>> GetResults(IList<string> searchTerms);
    }
}
