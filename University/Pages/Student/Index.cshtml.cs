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

        public async Task OnGetAsync()
        {
            Student = await _context.Students.ToListAsync();
        }
    }
}
