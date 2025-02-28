using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gym.Data;
using Gym.Models;

namespace Gym.Pages.Coaches
{
    public class DetailsModel : PageModel
    {
        private readonly GymContext _context;

        public DetailsModel(GymContext context)
        {
            _context = context;
        }

        public Coach Coach { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coaches.FirstOrDefaultAsync(m => m.Id == id);

            if (coach is not null)
            {
                Coach = coach;

                return Page();
            }

            return NotFound();
        }
    }
}
