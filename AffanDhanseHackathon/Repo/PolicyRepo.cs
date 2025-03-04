using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AffanDhanseHackathon.Models;

namespace AffanDhanseHackathon.Repo
{
    internal class PolicyRepo : IPolicyRepo
    {
         List<PolicyDetails> policies = new List<PolicyDetails>();

        //private int nextPolicyNum = 1;
        public void AddPolicy(PolicyDetails PolicyDetails)
        {
            if (policies.Any(p => p.PolicyID == PolicyDetails.PolicyID))
            {
                throw new PolicyNotFoundException("Policy ALready Exist.....");
            }
            //PolicyDetails.PolicyID = nextPolicyNum++;
            policies.Add(PolicyDetails);
        }

        public void DeletePolicy(int policyID)
        {
            PolicyDetails policyDetails = policies.FirstOrDefault(p => p.PolicyID == policyID);
            if (policyDetails == null)
            {
                throw new PolicyNotFoundException("policy Does not Exists.....");
            }
            policies.Remove(policyDetails);
        }

        public List<PolicyDetails> GetActivePolicy()
        {
            return policies.Where(p => p.PolicyActive()).ToList();
        }

        public List<PolicyDetails> GetAllPolicy()
        {
            return policies.ToList();
        }

        public PolicyDetails SearchPolicyById(int PolicyID)
        {
            bool checker = policies.Any(p => p.PolicyID == PolicyID);
            if (checker == true)
            {
                return policies.FirstOrDefault(p => p.PolicyID == PolicyID);
            }
            else
            {
                throw new PolicyNotFoundException("Policy Not Found!.....");
            }
        }

        public void UpdatePolicy(int PolicyID, PolicyDetails updatedPolicyDetails)
        {
            PolicyDetails existingPolicy = policies.FirstOrDefault(p => p.PolicyID == PolicyID );
            if (existingPolicy == null)
            {
            throw new PolicyNotFoundException("Policy Doesnot Exist......");
            }
            existingPolicy.PolicyID = updatedPolicyDetails.PolicyID;
            existingPolicy.PolicyHolderName = updatedPolicyDetails.PolicyHolderName;
            existingPolicy.PolicyType = updatedPolicyDetails.PolicyType;
            existingPolicy.StartDate = updatedPolicyDetails.StartDate;
            existingPolicy.EndDate = updatedPolicyDetails.EndDate;
        }

    }
}
