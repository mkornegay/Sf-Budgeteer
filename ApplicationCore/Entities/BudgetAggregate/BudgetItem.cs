using System;
using System.Collections.Generic;
using System.Text;

namespace Sf_Budgeteer_ApplicationCore.Entities.BudgetAggregate
{
    public class BudgetItem : BaseEntity
    {
        private BudgetItem()
        {
            //required by EF
        }

        public BudgetItem(decimal amount, AmountType amountType, BudgetCategory category)
        {
            Amount = amount;
            AmountType = amountType;
            Category = category;
        }

        public BudgetCategory Category { get; private set; }

        public decimal Amount { get; private set; }

        public AmountType AmountType { get; private set; }
    }
}
