using Funda.Business.Interface;
using Funda.DataAccess.Interface;
using Funda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funda.Business
{
    /// <inheritdoc/>
    public class MakelaarInfo : IMakelaarInfo
    {
        private readonly IAanbodService _aanbodService;


        public MakelaarInfo(IAanbodService aanbodService)
        {
            _aanbodService = aanbodService ?? throw new ArgumentNullException(nameof(aanbodService));
        }

        /// <inheritdoc/>
        public async Task<List<Makelaar>> GetTopMakelaars(string location, bool hasGarden)
        {
            var makelaarList = new List<Makelaar>();
            var fundaInformatie = await _aanbodService.GetKoopaanbodForLocation(location, hasGarden);
            if (fundaInformatie.Status != OperationStatus.Success)
            {
                return null;
            }
            var makelaaren = fundaInformatie.Aanbod.GroupBy(a => a.MakelaarId);
            foreach(var makelaar in makelaaren)
            {
                makelaarList.Add(new Makelaar
                {
                    MakelaarNaam = makelaar.FirstOrDefault().MakelaarNaam,
                    AanbodAantal = makelaar.Count()
                });
            }
            return makelaarList.OrderByDescending(m => m.AanbodAantal).Take(10).ToList();
        }

    }
}
