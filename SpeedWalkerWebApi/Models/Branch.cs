using System;
using System.Collections.Generic;

namespace SpeedWalkerWebApi.Models
{
    public partial class Branch
    {
        public int Id { get; set; }
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string GeoLocation { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
