using System;
using System.Collections.Generic;

namespace SpeedWalkerWebApi.Models
{
    public partial class AppraisalRecords
    {
        public int Id { get; set; }
        public int? AppraisalId { get; set; }
        public string StaffId { get; set; }
        public int? Teamwork { get; set; }
        public int? Punctuality { get; set; }
        public int? Attendance { get; set; }
        public int? Neatness { get; set; }
        public int? Creativity { get; set; }
        public int? ProblemSolving { get; set; }
        public string AdditionalComment { get; set; }
        public int? FinalScore { get; set; }
        public int? Year { get; set; }
        public int? Quarter { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? StaffUniqueId { get; set; }
        public int? SupervisorUniqueId { get; set; }
        public int? ManagerUniqueId { get; set; }
        public int? SupervisorAppraised { get; set; }
        public int? ManagerAppraised { get; set; }
        public string SupervisorScore { get; set; }
        public string ManagerScore { get; set; }
        public int SubmittedBy { get; set; }
    }
}
