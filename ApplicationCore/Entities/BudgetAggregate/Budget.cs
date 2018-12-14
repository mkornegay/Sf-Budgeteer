using Sf.Budgeteer.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sf.Budgeteer.ApplicationCore.Entities.BudgetAggregate
{
    public class Budget : BaseEntity, IAggregateRoot
    {
        private Budget()
        {
            // Required by EF if you have a public ctor 
            //  that takes parameters
        }

        public Budget(MonthEnumeration budgetMonth, int budgetYear, List<BudgetDetail> budgetDetails)
        {
            _budgetDetails.AddRange(budgetDetails);
            BudgetMonth = budgetMonth;
            BudgetYear = budgetYear;
        }

        private List<BudgetDetail> _budgetDetails = new List<BudgetDetail>();

        // making this IReadOnlyCollection is DDD best practice so that 
        //  buget items cannot be added outside the aggregate
        public IReadOnlyCollection<BudgetDetail> BudgetDetails => _budgetDetails.AsReadOnly();

        public MonthEnumeration BudgetMonth { get; private set; }

        public int BudgetYear { get; private set; }

        public void AddBudgetItem(decimal amount, AmountType amountType, BudgetCategory category)
        {
            _budgetDetails.Add(new BudgetDetail(amount, amountType, category));
        }
    }
}
