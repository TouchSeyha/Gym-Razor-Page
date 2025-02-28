using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gym.Data;
using Gym.Models;

namespace Gym.Pages.Schedules
{
    public class DetailsModel : PageModel
    {
        private readonly GymContext _context;

        public DetailsModel(GymContext context)
        {
            _context = context;
        }

        public Schedule Schedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules.FirstOrDefaultAsync(m => m.Id == id);

            if (schedule is not null)
            {
                Schedule = schedule;

                return Page();
            }

            return NotFound();
        }
    }
}
