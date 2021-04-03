using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_GoldChallangesThree_Repository
{

    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft,
    }
    public class ClaimContent
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }



        public ClaimContent() { }
        public ClaimContent(int claimID, ClaimType claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

    }

    

}
