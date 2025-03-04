using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AffanDhanseHackathon.Models;


namespace AffanDhanseHackathon.Repo
{
    internal interface IPolicyRepo
    {
        public void AddPolicy(PolicyDetails PolicyDetails);
        public void DeletePolicy(int policyID);
        public void UpdatePolicy(int PolicyID, PolicyDetails updatedPolicyDetails);

        public PolicyDetails SearchPolicyById(int PolicyID);
        public List<PolicyDetails> GetAllPolicy();
        public List<PolicyDetails> GetActivePolicy();

    }
}
