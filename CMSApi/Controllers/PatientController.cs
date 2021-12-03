﻿using CMSApi.Models;
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

        [HttpGet]
        [Route("GetPatients")]
        public async Task<IActionResult> GetPatients()
        {
            try
            {
                var staff = await patient.GetPatients();
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



        #region HttpPost
        [HttpPost]
        [Route("AddPatients")]
        public async Task<IActionResult> AddPatients([FromBody] TblPatients model)
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
        public async Task<IActionResult> UpdatePatients([FromBody]  TblPatients model)
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

        

        #region Get Patient By Id 
        [HttpGet("{id}")]
        public Task<ActionResult<TblPatients>> GetPatientById(int id)
        {
            try
            {
                var patients = patient.GetPatientById(id);
                if (patients == null)
                {
                    return null;
                }
                return patients;
            }

            catch (Exception)
            {

                return null;
            }
        }
        #endregion
        


    }
}
