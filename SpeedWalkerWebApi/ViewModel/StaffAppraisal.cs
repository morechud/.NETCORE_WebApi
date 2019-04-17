using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedWalkerWebApi.ViewModel
{
    public class StaffAppraisal
    {
        //AppraisalRecords Table
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

        //Staff table
        public string LastUpdated { get; set; }
        public string LastAppraisal { get; set; }

    }
}
