using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gym.Data;
using Gym.Models;

namespace Gym.Pages.Schedules
{
    public class CreateModel : PageModel
    {
        private readonly GymContext _context;

        public CreateModel(GymContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CoachId"] = new SelectList(_context.Coaches, "Id", "Id");
        ViewData["GymHallId"] = new SelectList(_context.GymHalls, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Schedule Schedule { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Schedules.Add(Schedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
