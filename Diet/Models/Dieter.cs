using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Diet.Models
{
    public class Dieter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        //[ForeignKey("DietPlan")]
        //public int DietPlanId { get; set; }
        //public DietPlan DietPlan { get; set; }

        //[ForeignKey("CreateDiet")]
        //public int CreateDietId { get; set; }
        //public CreateDiet CreateDiet { get; set; }

    }
}