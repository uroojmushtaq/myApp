using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsOnline.Models
{
    public class Car
    {
        public string name;
        public string price;


        [Display(Name = "Car Name:")]
        public String Name { get; set; }
        [Display(Name = "Enter Price:")]
        public int Price { get; set; }
    }
}