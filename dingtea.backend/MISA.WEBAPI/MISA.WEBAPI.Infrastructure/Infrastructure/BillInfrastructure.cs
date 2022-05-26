using System;
using System.Collections.Generic;
using Dapper;
using MISA.WEBAPI.Core.Entities;
using MISA.WEBAPI.Core.Interfaces.Infrastructure;
using MySqlConnector;

namespace MISA.WEBAPI.Infrastructure.Infrastructure
{
    public class BillInfrastructure : BaseInfrastructure<Bill>, IBillInfrastructure
    {
        public IEnumerable<Bill> getByCustomerId(Guid customerId)
        {
            using (_sqlConnection = new MySqlConnection(_connectionString))
            {
                //query insert
                var sqlCommand = $"SELECT * From Bill WHERE CustomerId = @customerId ORDER BY CreatedDate DESC";
                //parametter
                parameters = new DynamicParameters();
                parameters.Add("@customerId", customerId);
                //excute query
                var entity = _sqlConnection.Query<Bill>(sqlCommand, param: parameters);

                return entity;
            }
        }


    }
}
