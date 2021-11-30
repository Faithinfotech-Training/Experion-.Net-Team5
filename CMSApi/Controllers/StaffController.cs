using CMSApi.Models;
using CMSApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        IStaff postRepository;
        public StaffController(IStaff _p)
        {
            postRepository = _p;
        }


        //get staff
        #region get All staff

        [HttpGet]
        [Route("GetStaffbyId")]
        public async Task<IActionResult> GetStaffbyId(int id)
        {
            try
            {
                var staff = await postRepository.GetStaffbyId(id);
                if (staff == null)
                {
                    return NotFound();
                }
                return Ok(staff);
            }
            catch (Exception)
            {
                return BadRequest();
            }



        }

        [HttpGet]
        [Route("GetStaff")]
        public async Task<IActionResult> GetStaff()
        {
            try
            {
                var staff = await postRepository.GetStaff();
                if (staff == null)
                {
                    return NotFound();
                }
                return Ok(staff);
            }
            catch (Exception)
            {
                return BadRequest();
            }



        }
        //get department
        [HttpGet]
        [Route("GetDepartment")]
        public async Task<IActionResult> GetDepartment()
        {
            try
            {
                var staff = await postRepository.GetDepartment();
                if (staff == null)
                {
                    return NotFound();
                }
                return Ok(staff);
            }
            catch (Exception)
            {
                return BadRequest();
            }



        }

        //get designation
        [HttpGet]
        [Route("GetDesignation")]
        public async Task<IActionResult> GetDesignation()
        {
            try
            {
                var staff = await postRepository.GetDesignation();
                if (staff == null)
                {
                    return NotFound();
                }
                return Ok(staff);
            }
            catch (Exception)
            {
                return BadRequest();
            }



        }



        #endregion
        #region Add Staff

        [HttpPost]
        [Route("AddStaff")]
        public async Task<IActionResult> AddEmployee(Staffs staff)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await postRepository.Addstaff(staff);
                    if (postId != null)
                    {
                        return Ok(postId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

       

        #region Update Staff
        [HttpPut]
        // [Authorize]
        [Route("UpdateStaff")]
        public async Task<IActionResult> UpdateStaff(Staffs staff)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await postRepository.UpdateStaff(staff);
                    return Ok(staff);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

       
    }
}


