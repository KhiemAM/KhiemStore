using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KhiemStore.Models
{
    public class Product
    {
        [Key]
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string AvailabilityStatus { get; set; }
        public string Img { get; set; }

        public Nullable<long> CategoryID { get; set; }
        public Nullable<long> BrandID { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}