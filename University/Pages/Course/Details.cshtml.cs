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
    public class DetailsModel : PageModel
    {
        private readonly University.Dbo.SchoolContext _context;

        public DetailsModel(University.Dbo.SchoolContext context)
        {
            _context = context;
        }

        public Models.Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _context.Courses.FirstOrDefaultAsync(m => m.CourseID == id);

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
