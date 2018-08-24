using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RocketWorkflow.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [Display(Name = "Project name:")]
        public string JobName { get; set; }

        [Display(Name = "Assigned to: ")]
        public string AssignedEmployee { get; set; }

        [Display(Name = "Due date")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        [Display(Name = "Time completed")]

        [DataType(DataType.Date)]
        public DateTime CompleteTime { get; set; }


        [Display(Name = "Project fee:")]
        public double Fee { get; set; }

        [Display(Name = "Complete")]
        public bool IsComplete { get; set; }

        public bool IsArchived { get; set; }

        [Display(Name = "Billing status")]
        public bool BillingComplete { get; set; }
        public string SomeProp { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}