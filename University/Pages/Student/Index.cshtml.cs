using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using University.Dbo;
using University.Models;

namespace University.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly University.Dbo.SchoolContext _context;

        public IndexModel(University.Dbo.SchoolContext context)
        {
            _context = context;
        }

        public IList<University.Models.Student> Student { get;set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;
            if (!string.IsNullOrEmpty(CurrentFilter)) {
                Student = await _context.Students.Where(s => (s.LastName.ToUpper().Contains(CurrentFilter.ToUpper()) || s.FirstMidName.ToUpper().Contains(CurrentFilter.ToUpper()))).ToListAsync();
            }
            else {
                Student = await _context.Students.ToListAsync();
            }
        }
    }
}
