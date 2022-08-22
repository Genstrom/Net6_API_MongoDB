using EqspensesAPI.Settings;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EqspensesAPI.Entities;

[BsonCollection("users")]
public class User : Document
{
    public string GoogleUserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
}