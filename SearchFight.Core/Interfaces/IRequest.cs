using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Domain.Interfaces
{
    /// <summary>
    /// Represents a request with a response
    /// </summary>
    /// <typeparam name="TResponse">Response type</typeparam>
    public interface IRequest<out TResponse>
    {
    }
}
