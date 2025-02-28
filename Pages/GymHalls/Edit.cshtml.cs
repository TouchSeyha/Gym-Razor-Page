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

namespace Gym.Pages.GymHalls
{
    public class EditModel : PageModel
    {
        private readonly GymContext _context;

        public EditModel(GymContext context)
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

            var gymhall =  await _context.GymHalls.FirstOrDefaultAsync(m => m.Id == id);
            if (gymhall == null)
            {
                return NotFound();
            }
            GymHall = gymhall;
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

            _context.Attach(GymHall).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GymHallExists(GymHall.Id))
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

        private bool GymHallExists(int id)
        {
            return _context.GymHalls.Any(e => e.Id == id);
        }
    }
}
