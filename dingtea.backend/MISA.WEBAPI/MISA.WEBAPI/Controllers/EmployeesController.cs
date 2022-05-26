using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.WEBAPI.Models;
using Dapper;
using MySqlConnector;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.WEBAPI.Controllers
{
    
    [Route("api/v1/[controller]")]
    public class EmployeesController : Controller
    {

        //Khai bao thong tin CSDL
        string connectionString = "Server = 47.241.69.179;" +
            "Port = 3306;" +
            " Database = MISA.CukCuk_Demo_NVMANH_copy;" +
            "User Id = dev;" +
            " Password = manhmisa";

        /// <summary>
        /// Get all employee
        /// created by Ngo Dinh Thang(14/01/2022)
        /// </summary>
        // GET: api/controllers
        [HttpGet]
        public IActionResult Get()
        {
            
            //Khoi tao ket noi
            var sqlConnection = new MySqlConnection(connectionString);
            //query
            var sqlCommand = "SELECT * From Employee";
            //excute query
            var employees = sqlConnection.Query<Employee>(sqlCommand);

            return Ok(employees);
        }

        /// <summary>
        /// Get a employee by id
        /// created by Ngo Dinh Thang(14/01/2022)
        /// </summary>
        // GET api/Employees/id
        [HttpGet("{id}")]
        public IActionResult Get( Guid id)
        {
            //Khoi tao ket noi
            var sqlConnection = new MySqlConnection(connectionString);
            //query
            var sqlCommand = "SELECT * From Employee WHERE EmployeeId = @EmployeeId";
            //parametter
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeId", id);
            //excute query
            var employee = sqlConnection.QueryFirstOrDefault<Employee>(sqlCommand,param:parameters);

            return Ok(employee);
        }

        /// <summary>
        /// create one employee
        /// created by Ngo Dinh Thang(14/01/2022)
        /// </summary>

        // POST api/Employees
        [HttpPost]
        public IActionResult Post([FromBody] Employee newEmployee)
        {
            try {
                // EmployeeCode is not empty
                if (string.IsNullOrEmpty(newEmployee.EmployeeCode))
                {
                    var res = new {
                        devMsg = "EmployeeCode can not empty",
                        userMsg = "EmployeeCode can not empty"
                    };



                    return StatusCode(400, res);
                }

                var sqlConnection = new MySqlConnection(connectionString);
                // checkc duplicate EmployeeCode

                var queryExist = "SELECT * FROM Employee WHERE EmployeeCode = @EmployeeCode";

                var employeeCodeExist = sqlConnection.QueryFirstOrDefault<Employee>(queryExist, param: new { EmployeeCode = newEmployee.EmployeeCode });
                if (employeeCodeExist != null)
                {
                    var res = new
                    {
                        devMsg = "EmployeeCode is exists",
                        userMsg = "EmployeeCode is exists"
                    };



                    return StatusCode(400, res);
                }

                //insert 
                newEmployee.EmployeeId = Guid.NewGuid();
                string sqlCommand = $"INSERT INTO Employee(EmployeeId,EmployeeCode,FirstName,LastName,FullName,DateOfBirth,PhoneNumber,Email,Address) " +
                    $"VALUES (@EmployeeId,@EmployeeCode,@FirstName,@LastName,@FullName,@DateOfBirth,@PhoneNumber,@Email,@Address)";

                //dynamic parameter
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", newEmployee.EmployeeId);
                parameters.Add("@EmployeeCode", newEmployee.EmployeeCode);
                parameters.Add("@FirstName", newEmployee.FirstName);
                parameters.Add("@LastName", newEmployee.LastName);
                parameters.Add("@FullName", newEmployee.FullName);
                //parameters.Add("@GenderName", newEmployee.GenderName);
                parameters.Add("@DateOfBirth", newEmployee.DateOfBirth);
                parameters.Add("@PhoneNumber", newEmployee.PhoneNumber);
                parameters.Add("@Email", newEmployee.Email);
                parameters.Add("@Address", newEmployee.Address);
                //parameters.Add("@DepartmentName", newEmployee.DepartmentName);
                var respone = sqlConnection.Execute(sqlCommand, param: parameters);

                return StatusCode(201, respone);

            }catch(Exception ex)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    userMsg = "Error! Please contact to MISA",

                };
                return StatusCode(500, res);
            }
            }
        /// <summary>
        /// edit one employee
        /// created by Ngo Dinh Thang(14/01/2022)
        /// </summary>
        // PUT api/Employees
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Employee newEmployee)
        {
            try
            {
                //khoi tao ket noi
                var sqlConnection = new MySqlConnection(connectionString);

                //sql query
                string sqlCommand = $"Update Employee SET EmployeeCode=@EmployeeCode,FullName=@FullName " +
                    $"WHERE EmployeeId = @EmployeeId ";

                //dynamic parameter
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmployeeId", id);
                parameters.Add("@EmployeeCode", newEmployee.EmployeeCode);


                //Validate data
                parameters.Add("@FullName", newEmployee.FullName);
                if (string.IsNullOrEmpty(newEmployee.EmployeeCode))
                {
                    //respone error
                    var res = new
                    {
                        devMsg = "EmployeeCode can not empty",
                        userMsg = "EmployeeCode can not empty"
                    };



                    return StatusCode(400, res);
                }

                if (string.IsNullOrEmpty(newEmployee.FullName))
                {
                    //respone error
                    var res = new
                    {
                        devMsg = "FullName can not empty",
                        userMsg = "FullName can not empty"
                    };



                    return StatusCode(400, res);
                }





                //excute update
                var respone = sqlConnection.Execute(sqlCommand, param: parameters);

                return StatusCode(201, respone);
            }
            catch(Exception ex)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    userMsg = "Error! Please contact to MISA",

                };
                return StatusCode(500, res);
            }
        }



        /// <summary>
        /// delete one employee
        /// created by Ngo Dinh Thang(14/01/2022)
        /// </summary>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var sqlConnection = new MySqlConnection(connectionString);

                //check exist employeeId
                var queryExist = "SELECT * FROM Employee WHERE EmployeeId = @EmployeeId";
                var employeeCodeExist = sqlConnection.QueryFirstOrDefault<Employee>(queryExist, param: new { EmployeeId = id });
                if (employeeCodeExist == null)
                {
                    //respone error
                    var res = new
                    {
                        devMsg = "EmployeeId is not exists",
                        userMsg = "EmployeeId is not exists"
                    };



                    return StatusCode(400, res);
                }

                //query delete
                var sqlCommand = "DELETE FROM Employee WHERE EmployeeId = @EmployeeId";
                //excute query delete
                var respone = sqlConnection.Execute(sqlCommand, param: new { EmployeeId = id });
                return StatusCode(204, respone);
            }
            catch(Exception ex)
            {
                //respone error
                var res = new
                {
                    devMsg = ex.Message,
                    userMsg = "Error! Please contact to MISA",

                };
                return StatusCode(500, res);
            }



        }
    }
}
