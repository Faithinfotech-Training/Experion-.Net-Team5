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
    public class TestController : ControllerBase
    {
        //Constructor Dependency Injection for LabReportRepository
        ITest testRepository;
        public TestController(ITest _p)
        {
            testRepository = _p;
        }
        #region Get Test By PatientId
        [HttpGet("GetTestByPatientId/{id}")]
        public async Task<IActionResult> GetTestByPatientId(int id)
        {
            try
            {
                var report = await testRepository.GetTestByPatientId(id);
                if (report == null)
                {
                    return NotFound();
                }
                return Ok(report);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        #endregion

        #region Add Test
        [HttpPost]
  
        public async Task<IActionResult> AddTest([FromBody] Tests model)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var testId = await testRepository.AddTest(model);
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

        #region Update Test
        [HttpPut]
        
        public async Task<IActionResult> UpdatePrescription([FromBody] Tests model)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await testRepository.UpdateTest(model);
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

        #region Get Staff by department
        [HttpGet("GetStaffbyId/{id}")]
        public async Task<IActionResult> GetStaffbyId(int id)
        {
            try
            {
                var report = await testRepository.GetStaffbyId(id);
                if (report == null)
                {
                    return NotFound();
                }
                return Ok(report);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        #endregion
        [HttpGet]
        [Route("GetTest")]
        public async Task<IActionResult> GetTest()
        {
            try
            {
                var staff = await testRepository.GetTest();
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
