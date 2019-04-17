using System;
using Microsoft.AspNetCore.Mvc;
using SpeedWalkerWebApi.Repository;
using SpeedWalkerWebApi.Models;
using Microsoft.Extensions.Logging;

namespace SpeedWalkerWebApi.Controllers
{

    [Route("api/[controller]")]
    public class GCSAppraisalController : Controller
    {
        readonly ILogger<GCSAppraisalController> log;

        IGCSAppraisalRepository iGCSAppraisalRepository;
        public GCSAppraisalController(IGCSAppraisalRepository _iGCSAppraisalRepository, ILogger<GCSAppraisalController> _log)
        {
            iGCSAppraisalRepository = _iGCSAppraisalRepository;
            log = _log;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("GetStaffs")]
        public IActionResult GetStaffs(int? id)
        {
            log.LogInformation("Get Staffs request made: " + DateTime.Now);
            try
            {
                var staffs = iGCSAppraisalRepository.GetStaffs(id);
                if (staffs == null)
                {
                    log.LogError("No Staff returned");
                    return NotFound();
                }

                log.LogInformation("Staff data log sucessfully" + DateTime.Now);
                return Ok(staffs);
            }
            catch (Exception ex)
            {
                log.LogError("Error on GetStaff call" + ex.StackTrace);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetStaffById")]
        public IActionResult GetStaffById(int id)
        {
            log.LogInformation("Get Staffs request made: " + DateTime.Now);
            try
            {
                var staffRecords = iGCSAppraisalRepository.GetStaffById(id);
                if (staffRecords == null)
                {
                    log.LogError("No Staff returned");
                    return NotFound();
                }

                log.LogInformation("Staff data log sucessfully" + DateTime.Now);
                return Ok(staffRecords);
            }
            catch (Exception ex)
            {
                log.LogError("Error on GetStaff call" + ex.StackTrace);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetBranch")]
        public IActionResult GetBranches()
        {
            try
            {
                var branches = iGCSAppraisalRepository.GetBranches();
                if (branches == null)
                {
                    return NotFound();
                }

                return Ok(branches);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddBranch")]
        public IActionResult AddBranch([FromBody]Branch model)
        {

            try
            {
                var branchId = iGCSAppraisalRepository.AddBranch(model);
                if (branchId > 0)
                {
                    return Ok(branchId);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                String error = ex.StackTrace;

                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetAppraisalRecordsById")]
        public IActionResult GetAppraisalRecordsById(int Id)
        {
            try
            {
                var appraisalRecords = iGCSAppraisalRepository.GetAppraisalRecordsById(Id);
                if (appraisalRecords == null)
                {
                    return NotFound();
                }

                return Ok(appraisalRecords);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddAppraisalRecord")]
        public IActionResult AddAppraisalRecord([FromBody]AppraisalRecords model)
        {

            try
            {
                var appraisalRecordId = iGCSAppraisalRepository.AddAppraisalRecord(model);
                if (appraisalRecordId > 0)
                {
                    return Ok(appraisalRecordId);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                String error = ex.StackTrace;

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AuthenticateUser")]
        public IActionResult AuthenticateUser([FromBody]Users user)
        {

            var returnValue = iGCSAppraisalRepository.AuthenticateUser(user);

            return Ok(returnValue);
        }

        [HttpPost]
        [Route("CreateNewUser")]
        public IActionResult CreateNewUser([FromBody]Users user)
        {
            var returnValue = iGCSAppraisalRepository.CreateNewUser(user);

            return Ok(returnValue);
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers(int? id)
        {
            var returnValue = iGCSAppraisalRepository.GetUsers(id);

            return Ok(returnValue);
        }
    }
}