using System;
namespace MISA.WEBAPI.Core.Entities
{
    public class Product
    {
        #region properties

        public Guid ProductId { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string ManufactureCode { get; set; }

        public float Price { get; set; }

        public int ProductType { get; set; }

        public int Remain { get; set; }

        public string ImageName { get; set; }

        public string ImageToken { get; set; }



        #endregion
        #region Constructor
        public Product()
        {
        }
        #endregion
    }
}
