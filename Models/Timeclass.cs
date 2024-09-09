using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //Primary Key
using System.Linq;
using System.Web;

namespace PoolsExample.Models
{
    public class Timeclass
    {
        [Key]
        public int Time_id { get; set; }
        public string DayTime { get; set; }
        public double Day_Time_Disc_Rate { get; set; }
    }
}