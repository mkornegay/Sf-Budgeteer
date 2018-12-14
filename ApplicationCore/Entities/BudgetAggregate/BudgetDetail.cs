using System;
using System.Collections.Generic;
using System.Text;

namespace Sf.Budgeteer.ApplicationCore.Entities.BudgetAggregate
{
    public class BudgetDetail : BaseEntity
    {
        private BudgetDetail()
        {
            //required by EF
        }

        public BudgetDetail(decimal amount, AmountType amountType, BudgetCategory category)
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
