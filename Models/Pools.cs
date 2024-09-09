using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //PK
using System.Linq;
using System.Web;

namespace PoolsExample.Models
{
    public class Pools
    {
        [Key]
        public int Pool_Id { get; set; }
        public string Pool_Name { get; set; }
        public string Location { get; set; }
        public double Cost { get; set; }
    }
}