using System;

namespace SelamYemek.Common
{
    public class Product
    {
        #region Property
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }

        public Category Category { get; set; }
        #endregion
    }
}
