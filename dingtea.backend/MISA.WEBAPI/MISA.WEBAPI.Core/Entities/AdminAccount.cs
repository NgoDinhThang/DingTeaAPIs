using System;
namespace MISA.WEBAPI.Core.Entities
{
    public class AdminAccount
    {
        public string AccountName { get; set; }
        public string AccountPassword { get; set; }
        public DateTime CreatedDate { get; set; }
        public AdminAccount()
        {
        }
    }
}
