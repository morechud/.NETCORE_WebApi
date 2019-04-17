using SpeedWalkerWebApi.Models;
using SpeedWalkerWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedWalkerWebApi.Repository
{
    public interface IGCSAppraisalRepository
    {
        List<Staff> GetStaffs(int? id);

        Staff GetStaffById(int id);

        List<AppraisalRecords> GetAppraisalRecords();

        List<AppraisalRecords> GetAppraisalRecordsById(int id);

        List<AppraisalRecords> GetMyStaffAppraisalRecords(int id);

        List<Branch> GetBranches();

        int AddBranch(Branch branch);

        int AddAppraisalRecord(AppraisalRecords appraisalRecords);

        int UpdateAppraisalRecord(AppraisalRecords appraisalRecords);

        Users AuthenticateUser(Users user);

        int CreateNewUser(Users user);

        List<Users> GetUsers(int? id);
    }
}
