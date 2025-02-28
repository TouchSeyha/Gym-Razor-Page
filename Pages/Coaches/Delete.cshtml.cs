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
    public class DeleteModel : PageModel
    {
        private readonly GymContext _context;

        public DeleteModel(GymContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coach = await _context.Coaches.FindAsync(id);
            if (coach != null)
            {
                Coach = coach;
                _context.Coaches.Remove(Coach);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
