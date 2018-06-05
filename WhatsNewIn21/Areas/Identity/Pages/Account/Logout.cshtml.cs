using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace WhatsNewIn21.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly IHubContext<UsersHub> _usersHubContext;

        public LogoutModel(SignInManager<IdentityUser> signInManager,
                ILogger<LogoutModel> logger,
                IHubContext<UsersHub> usersHubContext)
        {
            _signInManager = signInManager;
            _logger = logger;
            _usersHubContext = usersHubContext;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            string username = User.Identity.Name;
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            await _usersHubContext.Clients.All.SendAsync("ReceiveSignOut", username);
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return Page();
            }
        }
    }
}