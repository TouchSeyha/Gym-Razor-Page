using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Gym.Data;
using Gym.Models;

namespace Gym.Pages.Schedules
{
    public class IndexModel : PageModel
    {
        private readonly GymContext _context;

        public IndexModel(GymContext context)
        {
            _context = context;
        }

        public IList<Schedule> Schedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Schedule = await _context.Schedules
                .Include(s => s.Coach)
                .Include(s => s.GymHall).ToListAsync();
        }
    }
}
