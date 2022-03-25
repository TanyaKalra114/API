
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace InsuranceAPI.Models
{
    public class Car
    {


        [Key]
        public Guid policy_id { get; set; }
        public string model_no{ get; set; }
        public string policy_type{ get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        
       
    }
}
