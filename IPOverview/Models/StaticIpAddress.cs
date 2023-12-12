
namespace Models
{
    public class StaticIpAddress
    {
        public string IpAddress { get; set; }
        public string? AssociatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
