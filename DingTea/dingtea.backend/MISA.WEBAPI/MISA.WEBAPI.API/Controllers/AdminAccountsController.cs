using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.WEBAPI.Core.Entities;
using MISA.WEBAPI.Core.Exceptions;
using MISA.WEBAPI.Core.Interfaces.Infrastructure;
using MISA.WEBAPI.Core.Interfaces.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.WEBAPI.API.Controllers
{
    public class AdminAccountsController : MISABaseController<AdminAccount>
    {
        IAdminAccountInfrastructure _accountAdminInfrastructure;

        //khoi tao chuc nang thong qua interface
        public AdminAccountsController(IBaseService<AdminAccount> baseService, IBaseInfrastructure<AdminAccount> baseInfrastructure, IAdminAccountInfrastructure adminAccountInfrastructure) : base(baseService, baseInfrastructure)
        {
            this._accountAdminInfrastructure = adminAccountInfrastructure;
        }
        [HttpPost("login")]
        public IActionResult GetAccount([FromBody] AdminAccount account)
        {
            try
            {
                //goi ham getall trong Interface IEmployeeInfrastructure
                var data = _accountAdminInfrastructure.login(account);
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
