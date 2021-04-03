using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_GoldChallangesThree_Repository
{
    public class ClaimContentRepo
    {
        public List<ClaimContent> _claimsList = new List<ClaimContent>();
        public Queue<ClaimContent> _claimsQueue = new Queue<ClaimContent>();




        public bool CreateNewClaim(ClaimContent newClaim)
        {
            _claimsList.Add(newClaim);
            _claimsQueue.Enqueue(newClaim);
            if (_claimsList.Contains(newClaim))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ClaimContent> GetClaimsList()
        {
            return _claimsList;
           
        }

       


    }
}
