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
    public class AccountsController : MISABaseController<UserAccount>
    {
        IAccountInfrastructure _accountInfrastructure;

        //khoi tao chuc nang thong qua interface
        public AccountsController(IBaseService<UserAccount> baseService, IBaseInfrastructure<UserAccount> baseInfrastructure, IAccountInfrastructure accountInfrastructure) : base(baseService, baseInfrastructure)
        {
            this._accountInfrastructure = accountInfrastructure;
        }
        [HttpPost("login")]
        public IActionResult GetAccount([FromBody] UserAccount account)
        {
            try
            {
                //goi ham getall trong Interface IEmployeeInfrastructure
                var data = _accountInfrastructure.login(account);
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

        [HttpGet("fetch/{code}")]
        public IActionResult GetAccountByCode( string code)
        {
            try
            {
                //goi ham getall trong Interface IEmployeeInfrastructure
                var data = _accountInfrastructure.GetEntityByCode(code);
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

        [HttpPut("changepass/{id}/{newPass}")]
        public IActionResult ChangePassword(Guid id,string newPass)
        {
            try
            {
                //goi ham getall trong Interface IEmployeeInfrastructure
                var data = _accountInfrastructure.ChangePass(id,newPass);
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
