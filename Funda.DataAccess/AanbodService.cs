using Funda.DataAccess.Interface;
using Funda.Models;
using FundaApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Funda.DataAccess
{
    /// <inheritdoc/>
    public class AanbodService : IAanbodService
    {
        private readonly IAanbod _aanbodClient;

        public AanbodService(IAanbod aanbodClient)
        {
            _aanbodClient = aanbodClient ?? throw new ArgumentNullException(nameof(aanbodClient));
        }

        /// <inheritdoc/>
        public async Task<FundaResponse> GetKoopaanbodForLocation(string location, bool hasGarden)
        {
            var aanbodRequest = new AanbodRequest(location, hasGarden);
            FundaResponse response;
            try
            {
                var aanbodResponseList = await GetAllPages(aanbodRequest);
                response = MapResultUtil.MapResponse(aanbodResponseList, hasGarden, location);
            }
            catch (Exception ex)
            {
                ((AanbodClient)_aanbodClient).Abort();
                response = MapResultUtil.MapFailure();
            }
            finally
            {
                await ((AanbodClient)_aanbodClient).CloseAsync();
            }
            return response;
        }

        private async Task<List<ZoekAanbodResponse>> GetAllPages(AanbodRequest aanbodRequest)
        {
            var aanbodResponseList = new List<ZoekAanbodResponse>();
            ZoekAanbodResponse aanbodResponse;

            do
            {
                aanbodResponse = await _aanbodClient.ZoekAanbodAsync(aanbodRequest.GenerateNextRequest());
                aanbodResponseList.Add(aanbodResponse);
            }
            while (aanbodResponse.HasMorePages());

            return aanbodResponseList;
        }
    }
}
