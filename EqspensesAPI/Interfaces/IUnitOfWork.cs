using EqspensesAPI.Repositories;

namespace EqspensesAPI.Interfaces;


    public interface IUnitOfWork
    {
        IUserService Users { get; }
        IExpenseService Expenses { get; }
    }
