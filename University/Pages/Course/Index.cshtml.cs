using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using University.Dbo;
using University.Models;

namespace University.Pages.Course
{
    public class IndexModel : PageModel
    {
        private readonly University.Dbo.SchoolContext _context;

        public IndexModel(University.Dbo.SchoolContext context)
        {
            _context = context;
        }

        public IList<Models.Course> Course { get;set; }

        public async Task OnGetAsync()
        {
            Course = await _context.Courses.ToListAsync();
        }
    }
}
