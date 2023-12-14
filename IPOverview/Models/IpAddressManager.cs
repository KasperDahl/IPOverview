
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

        // Get static IP address entry by IP address
        public StaticIpAddress? GetEntryByIpAddress(string ipAddress)
        {
            return ipAddresses.FirstOrDefault(entry => entry.IpAddress == ipAddress);
        }

        // Add initial static IP address entries
        public void AddInitialEntries()
        {
            AddIpAddress(new StaticIpAddress
            {
                IpAddress = "192.168.1.1",
                AssociatedUser = "DanelecTest",
                CreatedDate = new DateTime(2021, 1, 1)
            });
            AddIpAddress(new StaticIpAddress
            {
                IpAddress = "192.168.1.2",
                AssociatedUser = "R&D IP",
                CreatedDate = new DateTime(2022, 10, 2)
            });
            AddIpAddress(new StaticIpAddress
            {
                IpAddress = "192.168.1.3",
                AssociatedUser = "MVC App IP",
                CreatedDate = new DateTime(2023, 3, 3)
            });
        }
    }
}