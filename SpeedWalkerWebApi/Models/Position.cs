using System;
using System.Collections.Generic;

namespace SpeedWalkerWebApi.Models
{
    public partial class Position
    {
        public int Id { get; set; }
        public string PositionId { get; set; }
        public string PositionName { get; set; }
        public string Levels { get; set; }
        public string Rank { get; set; }
    }
}
