using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AffanDhanseHackathon.Models;
using AffanDhanseHackathon.Utility;

namespace AffanDhanseHackathon.Repo
{
    internal class PolicyRepo : IPolicyRepo
    {
        //List<PolicyDetails> policies = new List<PolicyDetails>();
        List<PolicyDetails> policies1 = new List<PolicyDetails>();
        SqlCommand cmd = null;
        string connstring;

        public PolicyRepo() 
        {
            cmd = new SqlCommand();
            connstring = DbUtil.GetConnectionString();

        }

        public List<PolicyDetails> GetAllPolicy()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connstring)) 
            {
                cmd.CommandText = "select * from policys";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PolicyDetails policy = new PolicyDetails(reader.GetInt32("PolicyID"), 
                        reader.GetString("PolicyHolderName"),
                        Enum.Parse<PolicyType>(reader.GetString("PolicyType")),
                        reader.GetDateTime("StartDate"),
                        reader.GetDateTime("EndDate"));
                    policies1.Add(policy);
                }
            }
           return policies1;
        }

        public void AddPolicy(PolicyDetails policyDetails)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                // Create a new command object each time to avoid parameter issues
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO policys (PolicyID, PolicyHolderName, PolicyType, StartDate, EndDate) " +
                                   "VALUES (@PolicyID, @PolicyHolderName, @PolicyType, @StartDate, @EndDate)";
                cmd.Connection = sqlConnection;

                cmd.Parameters.AddWithValue("@PolicyID", policyDetails.PolicyID);
                cmd.Parameters.AddWithValue("@PolicyHolderName", policyDetails.PolicyHolderName);
                cmd.Parameters.AddWithValue("@PolicyType", policyDetails.PolicyType.ToString());
                cmd.Parameters.AddWithValue("@StartDate", policyDetails.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", policyDetails.EndDate);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void DeletePolicy(int policyID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM policys WHERE PolicyID = @PolicyID";
                cmd.Connection = sqlConnection;

                cmd.Parameters.AddWithValue("@PolicyID", policyID);

                sqlConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new PolicyNotFoundException($"Policy with ID {policyID} does not exist.");
                }
            }
        }


        public void UpdatePolicy(int policyID, PolicyDetails updatedPolicyDetails)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE policys SET PolicyHolderName = @PolicyHolderName, " +
                                  "PolicyType = @PolicyType, StartDate = @StartDate, EndDate = @EndDate " +
                                  "WHERE PolicyID = @PolicyID";
                cmd.Connection = sqlConnection;

                cmd.Parameters.AddWithValue("@PolicyID", policyID);
                cmd.Parameters.AddWithValue("@PolicyHolderName", updatedPolicyDetails.PolicyHolderName);
                cmd.Parameters.AddWithValue("@PolicyType", updatedPolicyDetails.PolicyType.ToString());
                cmd.Parameters.AddWithValue("@StartDate", updatedPolicyDetails.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", updatedPolicyDetails.EndDate);

                sqlConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    throw new PolicyNotFoundException($"Policy with ID {policyID} does not exist.");
                }
            }
        }


        //public void AddPolicy(PolicyDetails PolicyDetails)
        //{
        //    if (policies.Any(p => p.PolicyID == PolicyDetails.PolicyID))
        //    {
        //        throw new PolicyNotFoundException("Policy ALready Exist.....");
        //    }
        //    policies.Add(PolicyDetails);
        //}

        //public void DeletePolicy(int policyID)
        //{
        //    PolicyDetails policyDetails = policies.FirstOrDefault(p => p.PolicyID == policyID);
        //    if (policyDetails == null)
        //    {
        //        throw new PolicyNotFoundException("policy Does not Exists.....");
        //    }
        //    policies.Remove(policyDetails);
        //}

        //public List<PolicyDetails> GetActivePolicy()
        //{
        //    return policies.Where(p => p.PolicyActive()).ToList();
        //}



        //public PolicyDetails SearchPolicyById(int PolicyID)
        //{
        //    bool checker = policies.Any(p => p.PolicyID == PolicyID);
        //    if (checker == true)
        //    {
        //        return policies.FirstOrDefault(p => p.PolicyID == PolicyID);
        //    }
        //    else
        //    {
        //        throw new PolicyNotFoundException("Policy Not Found!.....");
        //    }
        //}

        //public void UpdatePolicy(int PolicyID, PolicyDetails updatedPolicyDetails)
        //{
        //    PolicyDetails existingPolicy = policies.FirstOrDefault(p => p.PolicyID == PolicyID );
        //    if (existingPolicy == null)
        //    {
        //    throw new PolicyNotFoundException("Policy Doesnot Exist......");
        //    }
        //    existingPolicy.PolicyID = updatedPolicyDetails.PolicyID;
        //    existingPolicy.PolicyHolderName = updatedPolicyDetails.PolicyHolderName;
        //    existingPolicy.PolicyType = updatedPolicyDetails.PolicyType;
        //    //existingPolicy.StartDate = updatedPolicyDetails.StartDate;
        //    existingPolicy.EndDate = updatedPolicyDetails.EndDate;
        //}

    }
}
