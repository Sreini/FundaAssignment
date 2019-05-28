using Funda.Models;
using FundaApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Funda.DataAccess
{
    public static class MapResultUtil
    {
        public static FundaResponse MapResponse(List<ZoekAanbodResponse> zoekAanbodList, bool hasGarden, string location)
        {
            var Objects = new List<Funda.Models.Object>();
            
            foreach (var zoekAanbodResponse in zoekAanbodList)
            {
                if (zoekAanbodResponse.ZoekAanbodResult is null)
                {
                    return new FundaResponse
                    {
                        Status = OperationStatus.GeneralError,
                        Aanbod = null
                    };
                }
                var ObjectList = zoekAanbodResponse.ZoekAanbodResult.Objects.Select(o => new Funda.Models.Object
                {
                    HasGarden = hasGarden,
                    Location = location,
                    MakelaarId = o.MakelaarId,
                    MakelaarNaam = o.MakelaarNaam,

                });
                Objects.AddRange(ObjectList);
            }
            return new FundaResponse
            {
                Aanbod = Objects,
                Status = OperationStatus.Success
            };
        }

        public static FundaResponse MapAuthFailure() =>
            new FundaResponse
            {
                Status = OperationStatus.AuthenticationError,
                Aanbod = null
            };

        public static FundaResponse MapFailure() =>
            new FundaResponse
            {
                Status = OperationStatus.GeneralError,
                Aanbod = null
            };
    }
}
