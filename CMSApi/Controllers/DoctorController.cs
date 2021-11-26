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
        //Get all doctors
        [HttpGet]
        [Route("GetDoctors")]
        public async Task<ActionResult<IEnumerable<Doctors>>> GetDoctors()
        {


            try
            {
                // var categories = await context.Category.Include(c => c.Post).Where(c=>c.Post!=null).ToList();
                var doctors = await doctorRepository.GetDoctors();
                // var categories = await context.Category.Include(d => d.Post).ToList();
                //.Include(d => d.Category).Tolist(GetCategories);
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
    }
}
