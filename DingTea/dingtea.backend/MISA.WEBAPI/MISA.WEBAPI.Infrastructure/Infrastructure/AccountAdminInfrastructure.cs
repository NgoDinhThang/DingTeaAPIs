using System;
using System.Collections.Generic;
using Dapper;
using MISA.WEBAPI.Core.Entities;
using MISA.WEBAPI.Core.Interfaces.Infrastructure;
using MySqlConnector;

namespace MISA.WEBAPI.Infrastructure.Infrastructure
{
    public class AccountAdminInfrastructure:BaseInfrastructure<AdminAccount>,IAdminAccountInfrastructure
    {
        public IEnumerable<AdminAccount> login(AdminAccount account)
        {
            using (_sqlConnection = new MySqlConnection(_connectionString))
            {
                //query insert
                var sqlCommand = $"SELECT * From AdminAccount WHERE AccountName = @accountName AND AccountPassword= @accountPassword";
                //parametter
                parameters = new DynamicParameters();
                parameters.Add("@accountName", account.AccountName);
                parameters.Add("@accountPassword", account.AccountPassword);
                //excute query
                var entity = _sqlConnection.Query<AdminAccount>(sqlCommand, param: parameters);

                return entity;
            }
        }

    }
}
