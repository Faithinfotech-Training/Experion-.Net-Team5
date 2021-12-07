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
    public class PrescriptionController : ControllerBase
    {
        //Constructor Dependency Injection for LabReportRepository
        IPrescriptionRepo prescriptionRepo;
        public PrescriptionController(IPrescriptionRepo _p)
        {
            prescriptionRepo = _p;
        }


        [HttpGet]
        [Route("GetPrescriptions")]
        public async Task<IActionResult> GetPrescriptions()
        {
            try
            {
                var staff = await prescriptionRepo.GetPrescriptions();
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

        [HttpPost]
        [Route("AddPrescriptions")]
        public async Task<IActionResult> AddPrescriptions(TbllPrescription staff)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await prescriptionRepo.AddPrescriptions(staff);
                    if (postId != null)
                    {
                        return Ok(postId);
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



        #region Update Prescription
        [HttpPut]
        // [Authorize]
        [Route("UpdatePrescription")]
        public async Task<IActionResult> UpdatePrescription(TbllPrescription staff)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await prescriptionRepo.UpdatePrescription(staff);
                    return Ok(staff);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region get payment bill by id
        [HttpGet]
        //[Route("GetPrescriptionById")]
        [Route("GetPrescriptionById/{id}")]
        public async Task<IActionResult> GetPrescriptionById(int id)
        {
            try
            {
                var bill = await prescriptionRepo.GetPrescriptionById(id);
                if (bill == null)
                {
                    return NotFound();
                }
                return Ok(bill);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion
    }
}
