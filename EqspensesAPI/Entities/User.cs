using EqspensesAPI.Settings;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EqspensesAPI.Entities;

[BsonCollection("users")]
public class User : Document
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnore]
    public string Id { get; set; }

    [BsonIgnore] public string? AuthToken { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
}