using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Domain.Interfaces
{
    /// <summary>
    /// Represents an implementation of mediator pattern.
    /// </summary>
    /// <typeparam name="TRequest">The request to handle</typeparam>
    /// <typeparam name="TResponse">The response from the handler</typeparam>
    internal interface IRequestHandler<in TRequest, out TResponse>
    {
        /// <summary>
        /// Performs the work of a specific UseCase.
        /// </summary>
        /// <param name="data">Request data</param>
        /// <returns>Response data</returns>
        TResponse Handle(TRequest data);
    }
}
