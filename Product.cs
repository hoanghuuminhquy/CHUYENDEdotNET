using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.Web;
using System.IO;

namespace Shop_Asp.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string detail { get; set; }
        public double price { get; set; }
        public double pricenew { get; set; }
        //[DataType(DataType.Upload)]
        //[Display(Name = "Upload File")]
        //[Required(ErrorMessage = "Please choose file to upload.")]
        public string image { get; set; }
        //public HttpPostedFileBase image { get; set; }
        public DateTime date { get; set; }
        public int order { get; set; }
        public int status { get; set; }
        public int groupproduct_id { get; set; }
    }

    //public interface HttpPostedFileBase
    //{
    //    string FileName { get; }
    //    Stream OpenReadStream();
    //    void CopyTo(Stream target);
    //}
}
