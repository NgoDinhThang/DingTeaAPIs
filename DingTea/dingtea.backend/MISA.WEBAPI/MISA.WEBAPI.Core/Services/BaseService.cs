using System;
using System.Linq;
using MISA.WEBAPI.Core.Exceptions;
using MISA.WEBAPI.Core.Interfaces.Infrastructure;
using MISA.WEBAPI.Core.Interfaces.Services;
using MISA.WEBAPI.Core.MISAAttribute;

namespace MISA.WEBAPI.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        IBaseInfrastructure<MISAEntity> _baseInfrustracture;

        public BaseService(IBaseInfrastructure<MISAEntity> baseInfrustracture)
        {
            this._baseInfrustracture = baseInfrustracture;
        }
        /// <summary>
        /// thêm 1 bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// created by NDThang(14/02/2022)
        public object InsertService(MISAEntity entity)
        {
            //validate du lieu

            ValidateData(entity);

            ValidateEmployee(entity);
            //thuc hien them moi vao database
            var res = _baseInfrustracture.Insert(entity);

            return res;
        }

        public int UpdateService(MISAEntity entity, Guid entityId)
        {
            //validate du lieu

            //thuc hien them moi vao database
            var res = _baseInfrustracture.Update(entity ,entityId);

            return res;
        }

        /// <summary>
        /// validate data
        /// </summary>
        /// <param name="entity"></param>
        /// created by NDThang
        private void ValidateData(MISAEntity entity)
        {
            //lay cac property dc dinh nghia NotEmpty
            var props = entity.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop,typeof(NotEmty)));

            foreach(var prop in props)
            {
                //lấy ra giá trị thuộc tính
                var propValue = prop.GetValue(entity);

                //lấy tên thuộc tính
                var propName = prop.Name;

                var nameDisplay = string.Empty;
                //lấy theo attribute đã được định nghĩa
                var proppertyNames = prop.GetCustomAttributes(typeof(PropertyName),true);
                if(proppertyNames.Length > 0)
                {
                    nameDisplay = (proppertyNames[0] as PropertyName).Name;
                   

                }


                //
                if (propValue == null || string.IsNullOrEmpty(propValue.ToString()))
                {
                    nameDisplay = (nameDisplay == string.Empty ? propName : nameDisplay);
                    throw new MisaValidateException(string.Format(Core.Resources.Resources.infoNotEmpty,nameDisplay));
                }
            }
        }

        protected virtual void ValidateEmployee(MISAEntity entity)
        {

        }
    }
}
