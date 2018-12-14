using Sf.Budgeteer.ApplicationCore.Entities;
using Sf.Budgeteer.ApplicationCore.Entities.BudgetAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sf.Budgeteer.ApplicationCore.Interfaces
{
    public interface IBudgetService
    {
        Task AddBudgetAsync(MonthEnumeration month, int year, List<BudgetDetail> budgetDetails);

        Task AddBudgetCategoryAsync(string description);

        Task AddBudgetDetailAsync(BudgetDetail budgetDetail);

        Task<Budget> EditBudgetDetailAsync(BudgetDetail budgetDetail);

        Task<Budget> GetBudgetByIdAsync(int budgetId);

        Task<Budget> GetBudgetByMonthAndYearAsync(MonthEnumeration month, int year);


    }
}
