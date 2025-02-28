using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gym.Pages.ManageUsers
{
    [Authorize(Roles = "SeniorSupervisor")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            // Page logic here.
        }
    }
}
