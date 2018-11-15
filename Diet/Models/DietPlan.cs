using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diet.Models
{
    public class DietPlan
    {
       [Key]
       public int ID { get; set; }
       [Display(Name = "Calorie Limit")]
       public string CalorieLimit { get; set; }
       [Display(Name = "Potential Food Choice")]
       public string PotentialFood { get; set; }
       public string Food { get; set; }
       public string Calories { get; set; }
       [Display(Name = "Maximum Calories")]
       public string MaxCal { get; set; }
       [Display(Name = "Minimum Participants")]
       public string MinCal { get; set; }
       
        
    }
}