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
    public class PaymentBillController : ControllerBase
    {
        //Constructor Dependency Injection for PaymentBillRepository
        //1.Default constructor - PaymentBillController
        //2.IPaymentBillRepository

        IPaymentBillRepository paymentBillRepository;
        public PaymentBillController(IPaymentBillRepository _p)
        {
            paymentBillRepository = _p;
        }
        //generate payment bill
        #region get all payment bill details
        //get all payment bill details
        [HttpGet]
        [Route("GetPaymentBill")]
        public async Task<IActionResult> GetPaymentBill()
        {
            try
            {
                var bill = await paymentBillRepository.GetPaymentBill();
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

        #region add all payment bill details
        [HttpPost]
        [Route("AddPaymentBill")]
        public async Task<IActionResult> AddPaymentBill([FromBody] TblPaymentBill model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var billId = await paymentBillRepository.AddPaymentBill(model);
                    if (billId > 0)
                    {
                        return Ok(billId);
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

        #region update payment bill details
        [HttpPut]
        [Route("UpdatePaymentBill")]
        public async Task<IActionResult> UpdatePaymentBill([FromBody] TblPaymentBill model)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await paymentBillRepository.UpdatePaymentBill(model);
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

        #region get payment bill by id
        [HttpGet]
        [Route("GetPaymentBillById")]
        public async Task<IActionResult> GetPaymentBillById(int id)
        {
            try
            {
                var bill = await paymentBillRepository.GetPaymentBillById(id);
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
