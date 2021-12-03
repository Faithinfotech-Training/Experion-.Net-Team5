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
    public class LabReportController : ControllerBase
    {
        //Constructor Dependency Injection for LabReportRepository
        ILabReport labRepository;
        public LabReportController(ILabReport _p)
        {
            labRepository = _p;
        }


        #region Get Lab Reports
        [HttpGet("{id}")]
        //[Route("GetLabReports")]
        public async Task<IActionResult> GetLabReports(int id)
        {
            try
            {
                var report = await labRepository.GetLabReports(id);
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

        #region Get Lab Reports
        [HttpGet]
        //[Route("GetLabReports")]
        public async Task<IActionResult> GetLabReports()
        {
            try
            {
                var report = await labRepository.GetLabReports();
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
        [Route("GetReport")]
        public async Task<IActionResult> GetReport()
        {
            try
            {
                var staff = await labRepository.GetReport();
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
            #region Add Report
            [HttpPost]
            //checks for token
            //[Route("AddReport")]
            public async Task<IActionResult> AddClient(TblLabReport model)
            {
                //Check the validation of body
                if (ModelState.IsValid)
                {
                    try
                    {
                        var reportId = await labRepository.AddReport(model);
                        if (reportId > 0)
                        {
                            return Ok(reportId);
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
        



    }
}
