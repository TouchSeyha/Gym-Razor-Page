using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gym.Data;
using Gym.Models;

namespace Gym.Pages.GymHalls
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
            return Page();
        }

        [BindProperty]
        public GymHall GymHall { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GymHalls.Add(GymHall);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
