using Funda.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Funda.DataAccess.Interface
{
    /// <summary>
    /// interface for obtaining object listings on from the funda database
    /// </summary>
    public interface IAanbodService
    {
        /// <summary>
        /// obtains all objects at a given location and filtered based on whether or not they have a garden
        /// </summary>
        /// <param name="location"></param>
        /// <param name="hasGarden"></param>
        /// <returns></returns>
        Task<FundaResponse> GetKoopaanbodForLocation(string location, bool hasGarden);
    }
}
