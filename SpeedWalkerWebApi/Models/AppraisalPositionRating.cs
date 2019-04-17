using System;
using System.Collections.Generic;

namespace SpeedWalkerWebApi.Models
{
    public partial class AppraisalPositionRating
    {
        public int Id { get; set; }
        public int? Rating { get; set; }
        public int? ExpectedScore { get; set; }
        public string PositionId { get; set; }
    }
}
