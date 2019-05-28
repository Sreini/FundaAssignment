using FundaApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Funda.DataAccess
{
    /// <summary>
    /// a class encapsulating the details of generating requests for the funda api
    /// </summary>
    public  class AanbodRequest
    {
        //because WS-* bindings are not supported in .net core, wcf cannot read more than 25 objects at a time in the object array
        //had to find this out the hard way
        private const string PAGE_SIZE = "25";

        /// <summary>
        /// the current page number
        /// </summary>
        private int _pageNumber { get; set; }

        /// <summary>
        /// the location of the objects
        /// </summary>
        private string Location { get; set; }

        /// <summary>
        /// boolean representing whether or not the object has a garden
        /// </summary>
        private bool HasGarden { get; set; }

        
        public AanbodRequest(string location, bool hasGarden)
        {
            Location = location;
            HasGarden = hasGarden;
        }

        /// <summary>
        /// request generator
        /// </summary>
        /// <returns></returns>
        private ZoekAanbodRequest GenerateZoekAanbodRequest()
        {
            var key = "ac1b0b1572524640a0ecc54de453ea9f";
            var aanbodType = "koop";
            var zoekPad = HasGarden? $"/{Location}/tuin/" : $"/{Location}/";
            var pageNumber = _pageNumber.ToString();
            return new ZoekAanbodRequest(key, aanbodType, zoekPad, null, pageNumber, PAGE_SIZE, null, 0);
        }

        /// <summary>
        /// generates a request while advancing the page number
        /// </summary>
        /// <returns></returns>
        public ZoekAanbodRequest GenerateNextRequest()
        {
            _pageNumber++;
            return GenerateZoekAanbodRequest();
        }
    }
}
