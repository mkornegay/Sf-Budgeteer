﻿using Sf_Budgeteer_ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sf_Budgeteer_ApplicationCore.Entities.BudgetAggregate
{
    public class Budget : BaseEntity, IAggregateRoot
    {
        private Budget()
        {
            // Required by EF
        }

        public Budget(MonthEnumeration budgetMonth, int budgetYear, List<BudgetItem> budgetItems)
        {
            _budgetItems.AddRange(budgetItems);
            BudgetMonth = budgetMonth;
            BudgetYear = budgetYear;
        }

        private List<BudgetItem> _budgetItems = new List<BudgetItem>();

        // making this IReadOnlyCollection is DDD best practice so that 
        //  buget items cannot be added outside the aggregate
        public IReadOnlyCollection<BudgetItem> BudgetItems => _budgetItems.AsReadOnly();

        public MonthEnumeration BudgetMonth { get; private set; }

        public int BudgetYear { get; private set; }
    }
}