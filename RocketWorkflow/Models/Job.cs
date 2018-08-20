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
        public string JobId { get; set; }

        [ForeignKey("Client")]
        public string ClientId { get; set; }
        public Client Client { get; set; }
        public string JobName { get; set; }

        [Display(Name = "Assigned to ")]
        public string AssignedEmployee { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompleteTime { get; set; }
        public double Fee { get; set; }
        public bool IsComplete { get; set; }
        public bool IsArchived { get; set; }
        public bool BillingComplete { get; set; }
        public string SomeProp { get; set; }


    }
}