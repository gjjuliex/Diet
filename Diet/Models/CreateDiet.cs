using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diet.Models
{
    public class CreateDiet
    {
       public int ID { get; set; }
       public string DietPlanName { get; set; }
       public string Monday { get; set; }
       public string Tuesday { get; set; }
       public string Wednesday { get; set; }
       public string Thursday { get; set; }
       public string Friday { get; set; }
       public string Saturday { get; set; }
       public string Sunday { get; set; }
       public string Goal { get; set; }
   
    }
}