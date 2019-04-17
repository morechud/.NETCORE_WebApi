using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedWalkerWebApi.ViewModel
{
    public class StaffProfile
    {
        public int Id { get; set; }
        public string StaffId { get; set; }
        public string StaffName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Cluster { get; set; }
        public string SubDepartment { get; set; }
        public string ManagerId { get; set; }
        public string Rank { get; set; }
        public string BranchId { get; set; }
        public string SupervisorId { get; set; }
        public string LastUpdated { get; set; }
        public string LastAppraisal { get; set; }
        public string Status { get; set; }
        public int? ManagerUniqueId { get; set; }
        public int? SupervisorUniqueId { get; set; }
        public int? FinalScore { get; set; }
        public int? Year { get; set; }
        public int? Quarter { get; set; }
    }
}
