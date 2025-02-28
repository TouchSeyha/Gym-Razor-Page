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
    public class IndexModel : PageModel
    {
        private readonly GymContext _context;

        public IndexModel(GymContext context)
        {
            _context = context;
        }

        public IList<GymHall> GymHall { get;set; } = default!;

        public async Task OnGetAsync()
        {
            GymHall = await _context.GymHalls.ToListAsync();
        }
    }
}
