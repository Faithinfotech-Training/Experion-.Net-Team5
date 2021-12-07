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
    public class DTestListController : ControllerBase
    {
        IDTestList testListRepository;
        public DTestListController(IDTestList _p)
        {
            testListRepository = _p;
        }

        #region GetTestByPatientId
        [HttpGet]
        [Route("GetTestByPatientId/{id}")]
        public async Task<IActionResult> GetTestByPatientId(int id)
        {
            try
            {
                var app
                  = await testListRepository.GetTestByPatientId(id);
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

    }
}
