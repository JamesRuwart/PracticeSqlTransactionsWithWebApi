using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeWebApi.CommonClasses.Products
{
    public class Product : BaseResource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string GroupId { get; set; }
        public bool IsActive { get; set; }
    }
}
