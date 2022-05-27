using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MISA.WEBAPI.Core.Entities;

namespace MISA.WEBAPI.Core.Interfaces.Infrastructure
{
    public interface IBaseInfrastructure<MISAEntity>
    {
        /// <summary>
        /// lấy toàn bộ bản ghi
        /// </summary>
        /// <returns></returns>
        /// createdby NDThang(10/02/2022)
        IEnumerable<MISAEntity>  GetAll();

        /// <summary>
        /// lấy theo Id
        /// </summary>
        /// <returns></returns>
        /// createdby NDThang (10/02/2022)
        MISAEntity GetEntityById(Guid employeeId);

        /// <summary>
        /// lấy Xoá
        /// </summary>
        /// <returns></returns>
        /// createdby NDThang (10/02/2022)
        int Delete(Guid id);

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <returns></returns>
        /// createdby NDThang (10/02/2022)
        object Insert(MISAEntity entity);

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <returns></returns>
        /// createdby NDThang (10/02/2022)
        int Update(MISAEntity entity, Guid entityId );
    }
}
