using System.ComponentModel.DataAnnotations;

namespace InsuranceAPI.Models
{
    public class Claim
    {
        [Key]
        public Guid claim_id { get; set; }
        public string policy_no{ get;set;}
        public string policy_type { get; set; }


    }
}
