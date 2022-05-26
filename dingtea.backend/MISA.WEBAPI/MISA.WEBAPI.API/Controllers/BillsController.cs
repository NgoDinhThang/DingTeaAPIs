using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.WEBAPI.Core.Entities;
using MISA.WEBAPI.Core.Exceptions;
using MISA.WEBAPI.Core.Interfaces.Infrastructure;
using MISA.WEBAPI.Core.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.WEBAPI.API.Controllers
{


    //[Route("api/v1/[controller]")]
    public class BillsController : MISABaseController<Bill>
    {

        IBillInfrastructure _billInfrastructure;
        //khoi tao chuc nang thong qua interface
        public BillsController(IBaseService<Bill> baseService, IBaseInfrastructure<Bill> baseInfrastructure,IBillInfrastructure billInfrastructure) : base(baseService, baseInfrastructure)
        {
            this._billInfrastructure = billInfrastructure;
        }
        [HttpGet("fetch/{customerId}")]
        public IActionResult getByCustomerId( Guid customerId)
        {
            try
            {
                //goi ham getall trong Interface IEmployeeInfrastructure
                var data = _billInfrastructure.getByCustomerId(customerId);
                return StatusCode(200, data);
            }
            catch (MisaValidateException ex)
            {
                //trả lỗi về
                var respone = new
                {
                    usrMessage = ex.Message,
                    devMessage = ex.Message
                };
                return BadRequest(respone);
            }
            catch (Exception ex)
            {
                var respone = new
                {
                    usrMessage = Core.Resources.Resources.ErrorException,
                    devMessage = ex.Message
                };
                return StatusCode(500, ex.Message);
            }
        }






    }
   
}
