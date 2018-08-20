using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RocketWorkflow.Models
{
    public class Task
    {
        [Key]
        public string TaskId { get; set; }

        [Display(Name = "Assigned to ")]
        public string AssignedEmployee { get; set; }
        public DateTime DueDate { get; set;}
        public DateTime CompleteTime { get; set; }
        public bool IsComplete { get; set; }
        //public string TaskId { get; set; }
    }
}