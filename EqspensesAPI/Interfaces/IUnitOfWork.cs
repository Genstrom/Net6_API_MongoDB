using EqspensesAPI.Entities;

namespace EqspensesAPI.Interfaces;

public interface IUnitOfWork
{
    IMongoRepository<User> Users { get; }
    IMongoRepository<Expense> Expenses { get; }
}