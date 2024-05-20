using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpravaUdalosti.Data;

namespace SpravaUdalosti.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // Method for loading user information
        private async Task<List<UserInfo>> LoadUsersAsync()
        {
            var users = await _context.Users
                .Select(u => new UserInfo
                {
                    Name = u.UserName,
                    Email = u.Email,
                    Role = _context.UserRoles
                        .Where(r => r.UserId == u.Id)
                        .Join(_context.Roles, ur => ur.RoleId, r => r.Id, (ur, r) => r.Name)
                        .ToArray()
                }).ToListAsync();

            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

            var UserInRole = new Dictionary<string, List<string>>();
            foreach (var role in roles)
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(role);
                UserInRole.Add(role, usersInRole.Select(u => u.UserName).ToList());
            }

            foreach (var user in users)
            {
                user.Role = UserInRole
                    .Where(r => r.Value.Contains(user.Name))
                    .Select(r => r.Key)
                    .ToArray();
            }

            return users;
        }

        // Method for adding or removing a role from a user
        [HttpPost]
        public async Task<IActionResult> Roles(string userName, string roleName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (await _userManager.IsInRoleAsync(user, roleName))
            {
                await _userManager.RemoveFromRoleAsync(user, roleName);
            }
            else
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Method for displaying a list of users
        public async Task<ActionResult> Index()
        {
            var users = await LoadUsersAsync();
            return View(users);
        }

        public record UserInfo
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string[] Role { get; set; }
        }
    }
}
