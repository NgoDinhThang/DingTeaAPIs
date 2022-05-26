using System;
namespace MISA.WEBAPI.Models
{
    public class Employee
    {
        #region Properties

        public Guid EmployeeId { get; set; }

        public string EmployeeCode { get; set; }

        public string? FirstName { get; set; }


        public string? LastName { get; set; }

        public string FullName { get; set; }

        //public string? GenderName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }
        #endregion

        //public string? DepartmentName { get; set; }

        #region constructer employee

        public Employee()
        {
            
        }
        #endregion


    }
}
