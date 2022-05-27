using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MISA.WEBAPI.Core.Interfaces.Infrastructure;
using MISA.WEBAPI.Core.MISAAttribute;
using MySqlConnector;
using System.Linq;

namespace MISA.WEBAPI.Infrastructure.Infrastructure
{
    public class BaseInfrastructure<MisaEntity>:IBaseInfrastructure<MisaEntity>
    {
            //Khai bao thong tin CSDL
            protected string _connectionString = "Server = 127.0.0.1;" +
                                    "Port = 3306;" +
                                    " Database = DingTea;" +
                                    "User= root;" +
                                    " Password = Ngothang8a@";
        protected MySqlConnection _sqlConnection;

        //dynamic
        protected DynamicParameters parameters;

        //
        string className = typeof(MisaEntity).Name;

        /// <summary>
        /// Get all employee
        /// </summary>
        /// <returns></returns>
        /// created by NDThang(21/01/2022)
        public IEnumerable<MisaEntity> GetAll()
        {
            using (_sqlConnection = new MySqlConnection(_connectionString)) //use sqlconnection 
            {
                //query
                var sqlCommand = $"SELECT * From {className}";
                //excute query
                var entities = _sqlConnection.Query<MisaEntity>(sqlCommand);

                return entities;
            }
        }

        /// <summary>
        /// lấy ra dữ liệu theo Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// createdBy NDThang(12/02/2022)
        public virtual MisaEntity GetEntityById(Guid Id)
        {
            using (_sqlConnection = new MySqlConnection(_connectionString))
            {
                //query insert
                var sqlCommand = $"SELECT * From {className} WHERE {className}Id = @{className}Id";
                //parametter
                 parameters = new DynamicParameters();
                parameters.Add($"@{className}Id", Id);
                //excute query
                var entity = _sqlConnection.QueryFirstOrDefault<MisaEntity>(sqlCommand, param: parameters);

                return entity;
            }
        }


        public int Delete(Guid Id)
        {
            using (_sqlConnection = new MySqlConnection(_connectionString)) 
            {
                //query delete
                var sqlCommand = $"DELETE FROM {className} WHERE {className}Id = @{className}Id";

                parameters = new DynamicParameters();
                parameters.Add($"@{className}Id", Id);
                //excute query delete
                var respone = _sqlConnection.Execute(sqlCommand, param:parameters);
                return respone;
            }
        }

        /// <summary>
        /// thêm mới Employee
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual object Insert(MisaEntity entity)
        {
            var className = typeof(MisaEntity).Name;
            var sqlColumNames = new StringBuilder();
            var sqlColumnValues = new StringBuilder();
            DynamicParameters parameters = new DynamicParameters();

            var id = new Object();
            var delimiter = "";

            //lấy ra tất cả prperty của đối tượng
            var props = typeof(MisaEntity).GetProperties();
            foreach(var prop in props)
            {
                //lấy ra tên và giá trị của các property
                var propName = prop.Name;
                var propValue = prop.GetValue(entity);


                var paramName = $"@{propName}";

                //kiểm tra xem property có phải khoá chính không

                var primaryKey = Attribute.IsDefined(prop, typeof(PrimaryKey));

                if(primaryKey == true || propName == $"{className}Id")
                {
                    if(prop.PropertyType == typeof(Guid))
                    {
                        propValue = Guid.NewGuid();
                        id = propValue;
                    }
                }

                

                
                //append 
                sqlColumNames.Append($"{delimiter}{propName}");
                sqlColumnValues.Append($"{delimiter}{paramName}");
                delimiter = ",";
                //add parameter
                parameters.Add(paramName, propValue);
            }
            //thuc hien them vao cau lenh sql
            var sqlCommand = $"INSERT INTO {className}({sqlColumNames.ToString()}) VALUES ({sqlColumnValues.ToString()})";

            using (_sqlConnection = new MySqlConnection(_connectionString))
            {
                //thuc hien them moi vao database
                var respone = _sqlConnection.Execute(sqlCommand, param: parameters);
                var x = new
                {
                    respone,
                    id
                };
                return x;


            }

            }
        /// <summary>
        /// cập nhật Employee
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Update(MisaEntity entity, Guid entityId)
        {
            var className = typeof(MisaEntity).Name;
            var sqlSetValue = new StringBuilder();
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{className}Id", entityId);


            var delimiter = "";

            //lấy ra tất cả prperty của đối tượng
            var props = typeof(MisaEntity).GetProperties();
            foreach (var prop in props)
            {
                //lấy ra tên và giá trị của các property
                var propName = prop.Name;
                var propValue = prop.GetValue(entity);


                var paramName = $"@{propName}";

                //kiểm tra xem property có phải khoá chính không

                var primaryKey = Attribute.IsDefined(prop, typeof(PrimaryKey));

                //nếu là khoá chính thì bỏ qua(không cho phép thay đổi khoá chính)
                if (primaryKey == true || propName == $"{className}Id")
                {
                    continue;
                }

                //append 
                sqlSetValue.Append($"{delimiter}{propName}={paramName}");
                delimiter = ",";
                //add parameter
                parameters.Add(paramName, propValue);
            }
            //thuc hien them vao cau lenh sql
            var sqlCommand = $"Update {className} SET {sqlSetValue} Where {className}Id =@{className}Id ";

            using (_sqlConnection = new MySqlConnection(_connectionString))
            {
                //thuc hien them moi vao database
                var respone = _sqlConnection.Execute(sqlCommand, param: parameters);
                return respone;


            }

        }




    }
        
 }
