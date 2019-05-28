using Funda.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Funda.Business.Interface
{
    /// <summary>
    /// interface used to access information about makelaars
    /// </summary>
    public interface IMakelaarInfo
    {
        /// <summary>
        /// obtains the makelaars with the largest amount of aanbod at the specified location and filtered by whether or not the aanbod has a garden.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="hasGarden"></param>
        /// <returns></returns>
        Task<List<Makelaar>> GetTopMakelaars(string location, bool hasGarden);
    }
}
