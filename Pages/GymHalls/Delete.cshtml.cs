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
    public class DeleteModel : PageModel
    {
        private readonly GymContext _context;

        public DeleteModel(GymContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gymhall = await _context.GymHalls.FindAsync(id);
            if (gymhall != null)
            {
                GymHall = gymhall;
                _context.GymHalls.Remove(GymHall);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
