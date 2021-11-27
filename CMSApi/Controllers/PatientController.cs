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
        public async Task<IActionResult> UpdatePatients(Patients patient)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await patient.UpdatePatients(patient);
                    return Ok(patient);
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
