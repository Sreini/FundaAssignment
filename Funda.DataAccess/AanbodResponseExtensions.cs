using FundaApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Funda.DataAccess
{
    public static class AanbodResponseExtensions
    {
        /// <summary>
        /// returns a boolean indicating that there are more pages we can request
        /// </summary>
        /// <param name="aanbodResponse"></param>
        /// <returns></returns>
        public static bool HasMorePages(this ZoekAanbodResponse aanbodResponse) =>
             aanbodResponse.ZoekAanbodResult.Paging.VolgendeUrl != null;
        
    }
}
