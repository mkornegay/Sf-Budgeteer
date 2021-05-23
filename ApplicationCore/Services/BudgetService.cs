using Microsoft.Extensions.Logging;
using Sf.Budgeteer.ApplicationCore.Entities;
using Sf.Budgeteer.ApplicationCore.Entities.BudgetAggregate;
using Sf.Budgeteer.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sf.Budgeteer.ApplicationCore.Services
{
    public class BudgetService : IBudgetService
    {
        private IAsyncRepository<Budget> _budgetRepository;
        private IAsyncRepository<BudgetCategory> _budgetCategoryRepository;
        private ILogger<BudgetService> _logger;

        public BudgetService(IAsyncRepository<Budget> budgetRepository,
            IAsyncRepository<BudgetCategory> budgetCategoryRepository,
            ILogger<BudgetService> logger)
        {
            _budgetRepository = budgetRepository;
            _budgetCategoryRepository = budgetCategoryRepository;
            _logger = logger;
        }

        public async Task AddBudgetAsync(MonthEnumeration month, int year, List<BudgetDetail> budgetDetails)
        {
            var budget = new Budget(month, year, budgetDetails);
            await _budgetRepository.AddAsync(budget);
        }

        public async Task AddBudgetCategoryAsync(string description)
        {
            var budgetCategory = new BudgetCategory(description);
            await _budgetCategoryRepository.AddAsync(budgetCategory);
            
        }

        public Task AddBudgetDetailAsync(BudgetDetail budgetDetail)
        {
            throw new NotImplementedException();
        }

        public Task<Budget> EditBudgetDetailAsync(BudgetDetail budgetDetail)
        {
            throw new NotImplementedException();
        }

        public Task<Budget> GetBudgetByIdAsync(int budgetId)
        {
            throw new NotImplementedException();
        }

        public Task<Budget> GetBudgetByMonthAndYearAsync(MonthEnumeration month, int year)
        {
            throw new NotImplementedException();
        }
    }
}
