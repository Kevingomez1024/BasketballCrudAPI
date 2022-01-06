using System;
namespace BasketballCrudAPI.Data
{
    public class BballDbSettings : IBballDbSettings
    {
        public string RosterCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBballDbSettings
    {
        string RosterCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
