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
    public class DTestController : ControllerBase
    {
        //construct dependancy injection for postrepository
        IDtest doctorRepository;
        DBClinicContext context;
        public DTestController(IDtest _p)
        {
            doctorRepository = _p;

        }
        #region
        //Get all doctors
        [HttpGet]
        [Route("GetDTests")]
        public async Task<ActionResult<IEnumerable<Dtests>>> GetTests()
        {


            try
            {

                var doctors = await doctorRepository.GetTests();

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
        [Route("AddTest")]
        public async Task<IActionResult> AddTest([FromBody] Dtests model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var docId = await doctorRepository.AddTest(model);
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

        #region get all departments
        //Get all departments
        [HttpGet]
        [Route("GetTestName")]
        public async Task<ActionResult<IEnumerable<Ntests>>> GetTestName()
        {


            try
            {

                var dept = await doctorRepository.GetTestName();

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

        #region GetLabAppointmentByDate
        [HttpGet]
        [Route("GetLabAppointmentByDate/{date}")]
        public async Task<IActionResult> GetLabAppointmentByDate(DateTime date)
        {
            try
            {
                var app
                = await doctorRepository.GetLabAppointmentByDate(date);
                if (app == null)
                {
                    return NotFound();
                }
                return Ok(app);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Add Test Report
        [HttpPost]

        public async Task<IActionResult> AddTestReport([FromBody] TestResult model)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var testId = await doctorRepository.AddTestReport(model);
                    if (testId > 0)
                    {
                        return Ok(testId);
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

        [HttpGet]
        [Route("Gettest")]
        public async Task<IActionResult> Gettest()
        {
            try
            {
                var staff = await doctorRepository.Gettest();
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
        [Route("Getresult")]
        public async Task<IActionResult> Getresult()
        {
            try
            {
                var staff = await doctorRepository.Getresult();
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
    }
}
