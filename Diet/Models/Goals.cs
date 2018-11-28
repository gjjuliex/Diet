using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diet.Models
{
    public class Goals
    {
        [Key]
        public int GoalId { get; set; }
        public string LittleGoals{ get; set; }
  
        public string Goal { get; set; }


    }
}