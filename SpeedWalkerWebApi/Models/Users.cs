using System;
using System.Collections.Generic;

namespace SpeedWalkerWebApi.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public int? IsActive { get; set; }
        public int? IsSpecialUser { get; set; }
        public int? SpecialUserId { get; set; }
        public string AdditionalComments { get; set; }
        public string EmailAddress { get; set; }
        public int? IsExternalUser { get; set; }
        public string LastLoginDate { get; set; }
        public string LoginUntil { get; set; }
        public string StaffId { get; set; }
        public int StaffUniqueId { get; set; }
    }
}
