using Microsoft.EntityFrameworkCore;
using SpeedWalkerWebApi.Models;
using SpeedWalkerWebApi.Utilities;
using SpeedWalkerWebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedWalkerWebApi.Repository
{
    public class GCSAppraisalRepository : IGCSAppraisalRepository
    {
        GCSAppraisalDBContext db;
        public GCSAppraisalRepository(GCSAppraisalDBContext _db)
        {
            db = _db;
        }

        public List<Staff> GetStaffs(int? id)
        {
            List<Staff> lsStaffForAppraisal = new List<Staff>();
            if (db != null)
            {
                //check if the requestor is a supervisor or manager, if not return all staffs to admin
                if (id != null)
                {
                    var filteredStaffRecords = db.Staff.Where(s => s.SupervisorUniqueId == id || s.ManagerUniqueId == id).ToList<Staff>();
                    var filteredStaffAppraisal = db.AppraisalRecords.Where(a => a.ManagerAppraised == 0 && a.SupervisorUniqueId == id || a.ManagerUniqueId == id).ToList<AppraisalRecords>();

                    //check if the supervisor has appraised staff first before allow the manager to appraise. 
                    foreach (var staff in filteredStaffRecords)
                    {
                        if (id == staff.ManagerUniqueId)
                        {
                            if (filteredStaffAppraisal.Where(fa => fa.StaffUniqueId == staff.Id).Any())
                            {
                                lsStaffForAppraisal.Add(staff);
                            }
                        }
                        else
                        {
                            if (filteredStaffAppraisal.Where(fa => fa.StaffUniqueId != staff.Id).Any())
                            {
                                lsStaffForAppraisal.Add(staff);
                            }
                        }
                    }
                    return lsStaffForAppraisal;
                }
                return db.Staff.ToList();
            }
            return null;
                
        }

        public Staff GetStaffById(int id)
        {
            if (db != null)
            {
                return db.Staff.Where(s => s.Id == id).First<Staff>();
            }
            return null;
        }


        public List<AppraisalRecords> GetAppraisalRecords()
        {
            return null;
        }

        public List<AppraisalRecords> GetAppraisalRecordsById(int id)
        {
            return db.AppraisalRecords.Where(ar => ar.Id == id).ToList<AppraisalRecords>();
        }

        public List<AppraisalRecords> GetMyStaffAppraisalRecords(int id)
        {
            return db.AppraisalRecords.Where(ar => ar.ManagerUniqueId == id || ar.SupervisorUniqueId == id).ToList<AppraisalRecords>();
        }

        public  List<Branch> GetBranches()
        {
            return  db.Branch.ToList();
        }

        public int AddBranch(Branch branch)
        {
            if (db != null)
            {
                db.Branch.Add(branch);
                db.SaveChanges();
                return branch.Id;
            }
            return 0;
        }

        public int AddAppraisalRecord(AppraisalRecords appraisalRecords)
        {

            if (db != null)
            {
                if (appraisalRecords.SubmittedBy == appraisalRecords.ManagerUniqueId)
                {

                    UpdateAppraisalRecord(appraisalRecords);
                }
                else
                {
                    appraisalRecords.SupervisorAppraised = 1;
                    appraisalRecords.SupervisorScore = appraisalRecords.FinalScore.ToString();
                    appraisalRecords.Year = DateTime.Now.Year;
                    appraisalRecords.StartDate = DateTime.Now.ToShortDateString();
                    db.AppraisalRecords.Add(appraisalRecords);
                    db.SaveChanges();
                }

                return appraisalRecords.Id;
            }
            return 0;
        }

        public int UpdateAppraisalRecord(AppraisalRecords appraisalRecords)
        {
            var appraised = db.AppraisalRecords.Where(a => a.StaffUniqueId == appraisalRecords.StaffUniqueId);
            string managerComments = appraisalRecords.AdditionalComment;

            appraisalRecords.ManagerAppraised = 1; //manager appraised is set to 1 to tell the manager has appraised staff
            appraisalRecords.EndDate = DateTime.Now.ToShortDateString();
            appraisalRecords.ManagerScore = appraisalRecords.FinalScore.ToString();
            appraisalRecords.FinalScore += appraised.Select(ar => ar.FinalScore).First();
            appraisalRecords.AdditionalComment = "ManagerComments: "+ managerComments + ". Supervisor Comments: " 
                + appraised.Select(ar => ar.AdditionalComment).First().ToString();

            var queryReturnVal = db.AppraisalRecords.FromSql($"UPDATE AppraisalRecords SET ManagerAppraised ={appraisalRecords.ManagerAppraised}," +
                $"EndDate = {appraisalRecords.EndDate}, ManagerScore = {appraisalRecords.ManagerScore}, FinalScore = {appraisalRecords.FinalScore}, " +
                $"AdditionalComment = {appraisalRecords.AdditionalComment} WHERE StaffUniqueId = {appraisalRecords.StaffUniqueId} ").AsNoTracking();
            //db.AppraisalRecords.Update(tAppraisalRecords);
            //db.SaveChanges();
            return 1;
        }

        public Users AuthenticateUser(Users user)
        {
            Users returnUserInfo = db.Users.Where(u => u.UserId == user.UserId).ToList<Users>().First();
            if (user.UserId == returnUserInfo.UserId)
            {
                bool ispasswordverified = PasswordHelper.VerifyPassword(user.Password, returnUserInfo.Password);
                if (ispasswordverified)
                {
                    return new Users
                    {
                        UserId = returnUserInfo.UserId,
                        UserType = returnUserInfo.UserType,
                        StaffUniqueId = returnUserInfo.StaffUniqueId
                    };
                }
            }

            return null;

            //var returnUserInfo = db.Users.FromSql($"exec spUserLogin {user.UserId}, {user.Password}").AsNoTracking().ToList<Users>();
            //return returnUserInfo.First();
        }

        public int CreateNewUser(Users user)
        {
            Users newUser = new Users
            {
                UserId = user.UserId,
                Password = PasswordHelper.HashPassword(user.Password),
                UserType = user.UserType,
                IsActive = user.IsActive,
                IsSpecialUser = user.IsSpecialUser,
                SpecialUserId = user.SpecialUserId,
                AdditionalComments = user.AdditionalComments,
                EmailAddress = user.EmailAddress,
                IsExternalUser = user.IsExternalUser,
                LastLoginDate = DateTime.Now.ToLongTimeString(),
                LoginUntil = user.LoginUntil,
                StaffId = user.StaffId,
                StaffUniqueId = user.StaffUniqueId
            };
            if (db != null)
            {
                db.Users.Add(newUser);
                db.SaveChanges();
                return user.Id;
            }
            
            return 0;
        }

        public List<Users> GetUsers(int? id)
        {
            if (db != null)
            {
                if (!(id is null))
                {
                    return db.Users.ToList();
                    
                }
                return db.Users.Where(s => s.Id == id).ToList<Users>();
            }
            return null;
        }

    }
}
