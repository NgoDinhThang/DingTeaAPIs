using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.WEBAPI.Core.Exceptions;
using MISA.WEBAPI.Core.Interfaces.Infrastructure;
using MISA.WEBAPI.Core.Interfaces.Services;
using MISA.WEBAPI.Core.Resources;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.WEBAPI.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class MISABaseController<MISAEntity> : Controller
    {
        #region field
        IBaseService<MISAEntity> _baseService;
        IBaseInfrastructure<MISAEntity> _baseInfrastructure;

        #endregion

        #region constructor
        public MISABaseController(IBaseService<MISAEntity> baseService , IBaseInfrastructure<MISAEntity> baseInfrastructure)
        {
            _baseService = baseService;
            _baseInfrastructure = baseInfrastructure;
        }

        #endregion


        #region Method
        /// <summary>
        /// lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>200 - nếu có lỗi dữ liệu
        ///          400 - nếu có lỗi nghiệp vụ
        ///          500 - lỗi về backend
        /// </returns>
        /// created by NDThang(18/01/2022)
        /// 
        [HttpGet]
        public virtual IActionResult Get()
        {
            try
            {
                //gọi hàm getall trong infrastructure
                var data = _baseInfrastructure.GetAll();
                return Ok(data);
            }
            catch (MisaValidateException ex)
            {
                //trả về lỗi
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

        /// <summary>
        /// lấy dữ liệu theo id
        /// </summary>
        /// <returns>200 - nếu có lỗi dữ liệu
        ///          400 - nếu có lỗi nghiệp vụ
        ///          500 - lỗi về backend
        /// </returns>
        /// created by NgoDinhThang(18/01/2022)
        [HttpGet("{EntityId}")]
        public IActionResult GetById( Guid EntityId)
        {
            try
            {
                //goi ham getentityById trong Interface IEmployeeInfrastructure
                var data = _baseInfrastructure.GetEntityById(EntityId);
                return Ok(data);
            }
            catch (MisaValidateException ex)
            {
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


        /// <summary>
        /// thêm mới 1 bản ghi
        /// </summary>
        /// <returns>200 - nếu có lỗi dữ liệu
        ///          400 - nếu có lỗi nghiệp vụ
        ///          500 - lỗi về backend
        /// </returns>
        /// created by NgoDinhThang(18/01/2022)
        [HttpPost]
        public IActionResult Post( [FromBody] MISAEntity entity)
        {
            try
            {
                //goi ham getall trong Interface IEmployeeInfrastructure
                var data = _baseService.InsertService(entity);
                return StatusCode(201, data);
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


        /// <summary>
        /// Sua 1 ban ghi
        /// </summary>
        /// <returns>200 - neu sua thanh cong
        ///          400 - neu co loi ve nghiep vu
        ///          500 - loi ve backend
        /// </returns>
        /// created by NgoDinhThang(18/01/2022)
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] MISAEntity entity , Guid id)
        {
            try
            {
                //goi ham getall trong Interface IEmployeeInfrastructure
                var data = _baseService.UpdateService(entity,id);
                return StatusCode(200, data);
            }
            catch (MisaValidateException ex)
            {
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


        /// <summary>
        /// Xoa 1 ban ghi
        /// </summary>
        /// <returns>200 - neu xoa thanh cong
        ///          400 - neu co loi ve nghiep vu
        ///          500 - loi ve backend
        /// </returns>
        /// created by NgoDinhThang(18/01/2022)
        [HttpDelete("{id}")]
        public IActionResult Delete( Guid id)
        {
            try
            {
                //goi ham getall trong Interface IEmployeeInfrastructure
                var data = _baseInfrastructure.Delete(id);
                return StatusCode(200, data);
            }
            catch (MisaValidateException ex)
            {
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

        #endregion
    }

}
