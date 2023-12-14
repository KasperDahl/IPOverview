
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class StaticIpAddress
    {
        [RegularExpression(@"^\d{1,3}(\.\d{1,3}){3}$", ErrorMessage = "Invalid IP address format: should be 'xxx.xxx.xxx.xxx', where xxx is a 1-3 digit number.")]
        public required string IpAddress { get; set; }
        public string? AssociatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
