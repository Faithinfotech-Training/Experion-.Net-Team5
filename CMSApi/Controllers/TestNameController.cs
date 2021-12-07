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
    public class TestNameController : ControllerBase
    {
        //Constructor Dependency Injection for LabReportRepository
        ITestNameRepo testNameRepository;
        public TestNameController(ITestNameRepo _p)
        {
            testNameRepository = _p;
        }
        #region Get Test By PatientId
        [HttpGet("GetTestById/{id}")]
        public async Task<IActionResult> GetTestBytId(int id)
        {
            try
            {
                var report = await testNameRepository.GetTestById(id);
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


    }
}
