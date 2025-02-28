using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gym.Data;
using Gym.Models;

namespace Gym.Pages.Supervisors
{
    public class EditModel : PageModel
    {
        private readonly GymContext _context;

        public EditModel(GymContext context)
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

            var supervisor =  await _context.Supervisors.FirstOrDefaultAsync(m => m.Id == id);
            if (supervisor == null)
            {
                return NotFound();
            }
            Supervisor = supervisor;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Supervisor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupervisorExists(Supervisor.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SupervisorExists(int id)
        {
            return _context.Supervisors.Any(e => e.Id == id);
        }
    }
}
