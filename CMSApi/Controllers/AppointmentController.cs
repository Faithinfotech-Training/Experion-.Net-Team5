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
    public class AppointmentController : ControllerBase
    {
       //Constructor Dependency Injection for AppointmentRepository
        //1.Default constructor - AppointmentController
        //2.IAppointmentRepository

        IAppointmentRepository appointmentRepository;
        public AppointmentController(IAppointmentRepository _p)
        {
            appointmentRepository = _p;
        }

        //add appointment
        #region add appointment
        [HttpPost]
        [Route("AddAppointment")]
        public async Task<IActionResult> AddAppointment([FromBody] TblAppointment model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var appointmentId = await appointmentRepository.AddAppointment(model);
                    if (appointmentId > 0)
                    {
                        return Ok(appointmentId);
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

        //update appointment
        #region update appointment
        [HttpPut]
        [Route("UpdateAppointment")]
        public async Task<IActionResult> UpdateAppointment([FromBody] TblAppointment model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await appointmentRepository.UpdateAppointment(model);
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

        //get appointment details
        #region get appointment details
        [HttpGet]
        [Route("GetAppointment")]
        public async Task<IActionResult> GetAppointment()
        {
            try
            {
                var appointment = await appointmentRepository.GetAppointment();
                if (appointment == null)
                {
                    return NotFound();
                }
                return Ok(appointment);
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }
        #endregion

        //get appointment details by id
        #region get appointment by id
        [HttpGet]
        [Route("GetAppointmentById")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            try
            {
                var appointment = await appointmentRepository.GetAppointmentById(id);
                if (appointment == null)
                {
                    return NotFound();
                }
                return Ok(appointment);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion
    }
}
