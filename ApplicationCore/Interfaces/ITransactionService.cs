using Sf.Budgeteer.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sf.Budgeteer.ApplicationCore.Interfaces
{
    public interface ITransactionService
    {
        Task AddTransactionAsync(DateTime transactionDate, decimal amount, AmountType amountType, BudgetCategory budgetCategory);

        Task<Transaction> EditTransactionAsync(Transaction transaction);

        Task<Transaction> GetTransactionByIdAsync(int transactionId);

        Task<List<Transaction>> GetTransactionsByTypeAsync(AmountType amountType);

        Task<List<Transaction>> FindTransactionsAsync(ISpecification<Transaction> filter);


    }
}
