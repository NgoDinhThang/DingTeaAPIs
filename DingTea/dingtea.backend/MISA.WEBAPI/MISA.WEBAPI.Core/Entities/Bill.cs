using System;
namespace MISA.WEBAPI.Core.Entities
{
    public class Bill
    {
        public Guid BillId { get; set; }
        public int Amount { get; set; }
        public string Size { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Bill()
        {
        }
    }
}
