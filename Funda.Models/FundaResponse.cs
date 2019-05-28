using System;
using System.Collections.Generic;
using System.Text;

namespace Funda.Models
{
    public class FundaResponse
    {
        public List<Object> Aanbod { get; set; }

        public OperationStatus Status { get; set; }
    }
}
