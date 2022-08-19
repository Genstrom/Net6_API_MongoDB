using EqspensesAPI.Entities;
using EqspensesAPI.Interfaces;
using EqspensesAPI.Repositories;

namespace EqspensesAPI.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly IMongoDbSettings _mongoDbSettings;

    public UnitOfWork(IMongoDbSettings mongoDbSettings)
    {
        _mongoDbSettings = mongoDbSettings;
    }

    public IMongoRepository<User> Users => new MongoRepository<User>(_mongoDbSettings);
    public IMongoRepository<Expense> Expenses => new MongoRepository<Expense>(_mongoDbSettings);
}