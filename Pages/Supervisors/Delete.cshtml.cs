using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gym.Data;
using Gym.Models;

namespace Gym.Pages.Supervisors
{
    public class DeleteModel : PageModel
    {
        private readonly GymContext _context;

        public DeleteModel(GymContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Supervisor Supervisor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisor = await _context.Supervisors.FirstOrDefaultAsync(m => m.Id == id);

            if (supervisor is not null)
            {
                Supervisor = supervisor;

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

            var supervisor = await _context.Supervisors.FindAsync(id);
            if (supervisor != null)
            {
                Supervisor = supervisor;
                _context.Supervisors.Remove(Supervisor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
