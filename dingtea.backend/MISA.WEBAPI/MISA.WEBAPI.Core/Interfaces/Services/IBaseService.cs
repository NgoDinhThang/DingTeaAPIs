using System;
namespace MISA.WEBAPI.Core.Interfaces.Services
{
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// them moi du lieu
        /// </summary>
        /// <param name="MISAEntity"></param>
        /// <returns></returns>
        /// created by NgoDinhThang(19/01/2022)
        object InsertService(MISAEntity entity);
        /// <summary>
        /// Sua
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// created by NgoDinhThang(19/01/2022)
        int UpdateService(MISAEntity entity, Guid entityId);
    }
}
