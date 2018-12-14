using System;
using System.Collections.Generic;
using System.Text;

namespace Sf.Budgeteer.ApplicationCore.Entities
{
    public class Transaction : BaseEntity
    {
        public Transaction()
        {

        }

        public Transaction(DateTime transactionDate, decimal amount, 
            BudgetCategory category, AmountType amountType, 
            string description, string memo)
        {
            TransactionDate = transactionDate;
            Amount = amount;
            Category = category;
            AmountType = amountType;
            Description = description;
            Memo = memo;
        }

        public BudgetCategory Category { get; set; }
       
        public decimal Amount { get; set; }

        public AmountType AmountType { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Description { get; set; }

        public string Memo { get; set; }
    }
}
