using EqspensesAPI.Interfaces;
using MongoDB.Bson;

namespace EqspensesAPI.Entities;

public abstract class Document : IDocument
{
    public ObjectId Id { get; set; }

    public DateTime CreatedAt => Id.CreationTime;
}