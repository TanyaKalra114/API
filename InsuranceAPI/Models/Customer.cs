using System.ComponentModel.DataAnnotations;

namespace InsuranceAPI.Models
{
    public class Customer
    {
        [Key]
        public Guid customer_id { get; set; }
        public string customer_name { get; set; }
        public string gender { get; set; }
        public DateTime date_of_birth { get; set; }
        public int phone_no { get; set; }
        public string email { get; set; }

    }
}
