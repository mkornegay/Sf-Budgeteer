using System;
using System.Collections.Generic;
using System.Text;

namespace Sf.Budgeteer.ApplicationCore.Entities.BudgetAggregate
{
    public class BudgetItem : BaseEntity
    {
        public BudgetItem()
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

        public Budget Budget { get; set; }
    }
}
