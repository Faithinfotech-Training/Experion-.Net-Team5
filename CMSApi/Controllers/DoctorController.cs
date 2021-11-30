using CMSApi.Models;
using CMSApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        //construct dependancy injection for postrepository
        IDoctorRepo doctorRepository;
        DBClinicContext context;
        public DoctorController(IDoctorRepo _p)
        {
            doctorRepository = _p;

        }

        #region
        //Get  doctors
        [HttpGet]
        [Route("GetDoctors")]
        public async Task<ActionResult<IEnumerable<Doctors>>> GetDoctors()
        {


            try
            {

                var doctors = await doctorRepository.GetDoctors();

                if (doctors == null)
                {
                    return NotFound();
                }
                return Ok(doctors);
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }
        #endregion
        #region
        //Get all departments
        [HttpGet]
        [Route("GetDepartments")]
        public async Task<ActionResult<IEnumerable<Departments>>> GetDepartments()
        {


            try
            {

                var dept = await doctorRepository.GetDepartments();

                if (dept == null)
                {
                    return NotFound();
                }
                return Ok(dept);
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }
        #endregion

        #region Add a new post
        [HttpPost]
        [Route("AddDoctor")]
        public async Task<IActionResult> AddDoctor([FromBody] Doctors model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var docId = await doctorRepository.AddDoctor(model);
                    if (docId > 0)
                    {
                        return Ok(docId);
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

        #region Update Doctor
        [HttpPut]
        [Route("UpdateDoctor")]
        public async Task<IActionResult> UpdateDoctor([FromBody] Doctors model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await doctorRepository.UpdateDoctor(model);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region View all doctors
        [HttpGet]
        [Route("GetAllDoctors")]
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                var doctor = await doctorRepository.GetAllDoctors();
                if (doctor == null)
                {
                    return NotFound();
                }
                return Ok(doctor);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion
    }
}
