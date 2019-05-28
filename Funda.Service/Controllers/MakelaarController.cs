using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Funda.Business.Interface;
using Funda.DataAccess.Interface;
using Funda.Models;
using Microsoft.AspNetCore.Mvc;

namespace Funda.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MakelaarController : ControllerBase
    {
        private readonly IMakelaarInfo _makelaarInfo;

        public MakelaarController(IMakelaarInfo makelaarInfo)
        {
            _makelaarInfo = makelaarInfo ?? throw new ArgumentNullException(nameof(makelaarInfo));
        }

        // GET api/makelaar/Top10Makelaars/{location}
        [HttpGet]
        [Route("Top10Makelaars/{location}")]
        public async Task<ActionResult<List<Makelaar>>> Top10Makelaars(string location)
        {
            return await _makelaarInfo.GetTopMakelaars(location, false);
        }

        // GET api/makelaar/Top10MakelaarsMetTuin/{location}
        [HttpGet]
        [Route("Top10Makelaars/{location}/tuin")]
        public async Task<ActionResult<List<Makelaar>>> Top10MakelaarsMetTuin(string location)
        {
            return await _makelaarInfo.GetTopMakelaars(location, true);
        }

    }
}
