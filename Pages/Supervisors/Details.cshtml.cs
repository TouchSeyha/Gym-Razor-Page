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
    public class DetailsModel : PageModel
    {
        private readonly GymContext _context;

        public DetailsModel(GymContext context)
        {
            _context = context;
        }

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
    }
}
