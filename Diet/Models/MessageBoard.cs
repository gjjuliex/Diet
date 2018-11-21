using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Diet.Models
{
    public class MessageBoard
    {
        [Key]
        public int MessageBoardID { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public string Categories { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        //[ForeignKey("DietCat")]
        //public int DietCatId { get; set; }
        //public DietCat DietCat { get; set; }
    }

}