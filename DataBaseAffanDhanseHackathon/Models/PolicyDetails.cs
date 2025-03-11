using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffanDhanseHackathon.Models
{
   

    internal class PolicyDetails
    {
        public int PolicyID { get; set; }
        public string PolicyHolderName { get; set; }
        public PolicyType PolicyType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public PolicyDetails(int policyId, string policyHolderName, PolicyType policyType, DateTime startDate, DateTime endDate)
        {
            PolicyID = policyId;
            PolicyHolderName = policyHolderName;
            PolicyType = policyType;
            StartDate = startDate;
            EndDate = endDate;
        }
        public bool PolicyActive()
        {
           return DateTime.Now > StartDate && DateTime.Now < EndDate;
        }
        public override string ToString()
        {
            return $"PolicyId:: {PolicyID}\nPolicy Holder Name:: {PolicyHolderName}\nPolicy Type:: {PolicyType}\nStart Date:: {StartDate}\nEnd Date:: {EndDate}";
        }


    }
}
