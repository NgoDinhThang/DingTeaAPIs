using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MISA.WEBAPI.Core.Entities;
using MISA.WEBAPI.Core.Interfaces.Infrastructure;
using MySqlConnector;

namespace MISA.WEBAPI.Infrastructure.Infrastructure
{
    public class AccountInfrastructure : BaseInfrastructure<UserAccount>, IAccountInfrastructure
    {
        public IEnumerable<UserAccount> login(UserAccount account)
        {
            using (_sqlConnection = new MySqlConnection(_connectionString))
            {
                //query insert
                var sqlCommand = $"SELECT * From UserAccount WHERE AccountName = @accountName AND AccountPassword= @accountPassword";
                //parametter
                parameters = new DynamicParameters();
                parameters.Add("@accountName", account.AccountName);
                parameters.Add("@accountPassword", account.AccountPassword);
                //excute query
                var entity = _sqlConnection.Query<UserAccount>(sqlCommand, param: parameters);

                return entity;
            }
        }

        public override object Insert(UserAccount account)
        {

            var className = typeof(UserAccount).Name;
            var sqlColumNames = new StringBuilder();
            var sqlColumnValues = new StringBuilder();
            DynamicParameters parameters = new DynamicParameters();


            var delimiter = "";

            //lấy ra tất cả prperty của đối tượng
            var props = typeof(UserAccount).GetProperties();
            foreach (var prop in props)
            {
                //lấy ra tên và giá trị của các property
                var propName = prop.Name;
                var propValue = prop.GetValue(account);


                var paramName = $"@{propName}";




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

                return new { respone};


            }
        }

        public UserAccount GetEntityByCode(string userCode)
        {
            using (_sqlConnection = new MySqlConnection(_connectionString))
            {
                //query insert
                var sqlCommand = $"SELECT * From UserAccount WHERE CustomerCode = @customerCode";
                //parametter
                parameters = new DynamicParameters();
                parameters.Add($"@customerCode", userCode);
                //excute query
                var entity = _sqlConnection.QueryFirstOrDefault<UserAccount>(sqlCommand, param: parameters);

                return entity;
            }
        }

        public int ChangePass(Guid id, string newPass)
        {
            using (_sqlConnection = new MySqlConnection(_connectionString))
            {
                //query insert
                var sqlCommand = $"UPDATE UserAccount SET AccountPassword = @newPass WHERE CustomerId = @id";
                //parametter
                parameters = new DynamicParameters();
                parameters.Add($"@newPass", newPass);
                parameters.Add($"@id", id);
                //excute query
                var entity = _sqlConnection.Execute(sqlCommand, param: parameters);

                return entity;
            }
        }
    }

}
