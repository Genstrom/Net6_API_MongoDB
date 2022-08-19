using EqspensesAPI.Interfaces;

namespace EqspensesAPI.Settings;

public class MongoDbSettings : IMongoDbSettings
{
    public string? DatabaseName { get; set; }
    public string ConnectionString { get; set; }
}