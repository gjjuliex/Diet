using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Diet.Models
{
    public class User
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}