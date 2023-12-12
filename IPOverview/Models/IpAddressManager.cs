
namespace Models
{
    public class IpAddressManager
    {
        private HashSet<StaticIpAddress> ipAddresses;

        public IpAddressManager()
        {
            ipAddresses = new HashSet<StaticIpAddress>();
            AddInitialEntries();
        }

        // Add new static IP address entry
        public bool AddIpAddress(StaticIpAddress entry)
        {
            return ipAddresses.Add(entry);
        }

        // Remove static IP address entry
        public bool RemoveIpAddress(string ipAddress)
        {
            return ipAddresses.RemoveWhere(entry => entry.IpAddress == ipAddress) > 0;
        }

        // Check if static IP address entry exists
        public bool IpAddressExists(string ipAddress)
        {
            return ipAddresses.Any(entry => entry.IpAddress == ipAddress);
        }

        // Get all static IP address entries
        public IEnumerable<StaticIpAddress> GetAllEntries()
        {
            return ipAddresses ?? Enumerable.Empty<StaticIpAddress>();
        }

        // Add initial static IP address entries
        public void AddInitialEntries()
        {
            AddIpAddress(new StaticIpAddress
            {
                IpAddress = "192.168.1.1",
                AssociatedUser = "User1",
                CreatedDate = new DateTime(2023, 1, 1)
            });
            AddIpAddress(new StaticIpAddress
            {
                IpAddress = "192.168.1.2",
                AssociatedUser = "User2",
                CreatedDate = new DateTime(2023, 1, 2)
            });
            AddIpAddress(new StaticIpAddress
            {
                IpAddress = "192.168.1.3",
                AssociatedUser = "User3",
                CreatedDate = new DateTime(2023, 1, 3)
            });
        }
    }
}