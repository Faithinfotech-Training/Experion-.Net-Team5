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
    public class PatientController : ControllerBase
    {
        //Constructor dependency Injection
        IPatient patient;
        public PatientController(IPatient _p)
        {
            patient = _p;
        }

        #region HttpGet

        [HttpGet]
        [Route("GetAllPatients")]
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var patients = await patient.GetAllPatients();
                if (patients == null)
                {
                    return NotFound();
                }
                return Ok(patients);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        #endregion


        #region HttpPost
        [HttpPost]
        [Route("AddPatients")]
        public async Task<IActionResult> AddPatients([FromBody] Patients model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var patientId = await patient.AddPatients(model);
                    if (patientId != null)
                    {
                        return Ok(patientId);
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

        #region HttpPut

        [HttpPut]
        [Route("UpdatePatients")]
        public async Task<IActionResult> UpdatePatients([FromBody]  Patients model)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await patient.UpdatePatients(model);
                    return Ok(model);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region GetPatient
        [HttpGet]
        [Route("GetPatient")]
        public async Task<IActionResult> GetPatient(int id)
        {
            try
            {
                var pat = await patient.GetPatient(id);
                if (pat != null)
                {
                    return Ok(pat);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion
        /*#region GetPatientDetails
        [HttpGet]
        [Route("GetPatientDetails")]
        public async Task<IActionResult> GetPatientDetails(int id)
        {
            try
            {
                var pat = await patient.GetPatientDetails(id);
                if (pat != null)
                {
                    return Ok(pat);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion*/
        #region Get Patient By Id 
        [HttpGet]
        public Task<ActionResult<Patients>> GetPatientById(int id)
        {
            try
            {
                var pat = patient.GetPatientById(id);
                if (pat == null)
                {
                    return null;
                }
                return pat;
            }

            catch (Exception)
            {

                return null;
            }
        }
        #endregion
    }
}
