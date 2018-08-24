using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RocketWorkflow.Models.ViewModels
{
    public class MainViewModel
    {
        public List<Client> ClientsList { get; set; }

        public List<string> ClientFullNames { get; set; }

        public Client Client { get; set; }

        public List<Job> JobsList { get; set; }

        public Job Job { get; set; }

        public List<Task> TasksList { get; set; }
        public Task Task { get; set; }

        public OfficeAdmin OfficeAdmin { get; set; }

        public Accountant Accountant { get; set; }




    }
}