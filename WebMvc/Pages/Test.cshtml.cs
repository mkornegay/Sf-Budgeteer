using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages
{
    public class TestModel : PageModel
    {
        private readonly List<string> testItems;

        public TestModel()
        {
            for (int i = 0; i < 5; i++)
            {
                testItems.Add($"This is the {i.ToString()} item");
            }
        }
        public void OnGet()
        {
            return testItems;

        }
    }
}
