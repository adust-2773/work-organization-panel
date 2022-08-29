using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkOrganizationPanel.Client.Services;
using WorkOrganizationPanel.Database.Entities;
using WorkOrganizationPanel.Shared.Dtos;

namespace WorkOrganizationPanel.Server.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAccountService _accountService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAccountService accountService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountService = accountService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var newUser = new ApplicationUser
            {
                UserName = dto.Firstname,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Email = dto.Email
            };

            if (dto.Password != dto.PasswordRepeat)
            {
                return NotFound();
            }

            var result = await _userManager.CreateAsync(newUser, dto.Password);

            if (result.Succeeded)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var foundUser = await _userManager.FindByEmailAsync(dto.Email);

            if (foundUser == null)
            {
                return Unauthorized();
            }

            var result = await _signInManager.PasswordSignInAsync(foundUser, dto.Password, true, false);

            if (result.Succeeded)
            {
                return Ok();
            }

            return Unauthorized();
        }

        [HttpGet]
        [Route("userislogged")]
        public IActionResult UserIsLogged()
        {
            return !User.Identity.IsAuthenticated ? Unauthorized() : Ok();
        }
    }
}