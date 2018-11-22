using System;
using System.Collections.Generic;
using System.Text;

namespace Sf.Budgeteer.ApplicationCore.Entities
{
    public class BudgetCategory : BaseEntity
    {
        private BudgetCategory()
        {
            //Required by EF
        }

        public BudgetCategory(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}
