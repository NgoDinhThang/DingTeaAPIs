using System;
namespace MISA.WEBAPI.Core.Entities
{
    public class UserAccount
    {
        public string AccountName { get; set; }
        public string AccountPassword { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CustomerId { get; set; }
        public string CustomerCode { get; set; }
        public UserAccount()
        {
        }
    }
}
