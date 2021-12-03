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
    public class MedicineController : ControllerBase
    {
        IMedicineRepo medicinerepo;
        public MedicineController(IMedicineRepo _p)
        {
            medicinerepo = _p;
        }
        #region getmedicine
        //get medicine
        [HttpGet]
        [Route("GetMedicines")]
        public async Task<IActionResult> GetMedicines()
        {
            try
            {
                var staff = await medicinerepo.GetMedicines();
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
        #endregion




        #region add medicine
        [HttpPost]
        [Route("AddMedicine")]
        public async Task<IActionResult> AddMedicine([FromBody] TbllMedicines model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var appointmentId = await medicinerepo.AddMedicine(model);
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
        #region Update medicine
        [HttpPut]
        // [Authorize]
        [Route("UpdateMedicine")]
        public async Task<IActionResult> UpdateMedicine([FromBody]  TbllMedicines staff)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await medicinerepo.UpdateMedicine(staff);
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
        #region Get medicine By Id 
        [HttpGet("{id}")]
        public Task<ActionResult<TbllMedicines>> GetMedicineById(int id)
        {
            try
            {
                var patients = medicinerepo.GetMedicineById(id);
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
