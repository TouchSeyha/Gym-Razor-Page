using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gym.Data;
using Gym.Models;

namespace Gym.Pages.GymHalls
{
    public class DetailsModel : PageModel
    {
        private readonly GymContext _context;

        public DetailsModel(GymContext context)
        {
            _context = context;
        }

        public GymHall GymHall { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gymhall = await _context.GymHalls.FirstOrDefaultAsync(m => m.Id == id);

            if (gymhall is not null)
            {
                GymHall = gymhall;

                return Page();
            }

            return NotFound();
        }
    }
}
