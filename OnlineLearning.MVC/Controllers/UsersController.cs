using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLearning.Entity.Entities;
using OnlineLearning.Service.ViewModels;

namespace OnlineLearning.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Select(user => new UserViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                Roles = _userManager.GetRolesAsync(user).Result
            }).ToListAsync();

            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await _roleManager.Roles
                .Select(role => new RoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                }).ToListAsync();

            var viewModel = new AddUserViewModel
            {
                Roles = roles
            };

            return View(viewModel);
        }


        // POST: Add a new user and assign roles
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddUserViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            // Check if at least one role is selected
            if (!model.Roles.Any(r => r.IsSelected))
            {
                ModelState.AddModelError("Roles", "Please select at least one role.");
                return View(model);
            }

            // Check if the email already exists
            if (await _userManager.FindByEmailAsync(model.Email) != null)
            {
                ModelState.AddModelError("Email", "Email already exists.");
                return View(model);
            }

            // Check if the username already exists
            if (await _userManager.FindByNameAsync(model.UserName) != null)
            {
                ModelState.AddModelError("UserName", "Username already exists.");
                return View(model);
            }

            // Create the new user
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName
            };

            // Attempt to create the user
            var result = await _userManager.CreateAsync(user, model.Password);

            // If the user creation failed, show the errors
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            // Add the selected roles to the new user
            var selectedRoles = model.Roles.Where(r => r.IsSelected).Select(r => r.RoleName);
            await _userManager.AddToRolesAsync(user, selectedRoles);

            // Redirect to index after successful creation
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            var viewModel = new ProfileFormViewModel
            {
                Id = userId,
                FullName = user.FullName,
                UserName=user.UserName,
                Email = user.Email

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
                return NotFound();

            var userWithSameEmail = await _userManager.FindByEmailAsync(model.Email);
            
            if(userWithSameEmail != null &&  userWithSameEmail.Id != model.Id)
            {
                ModelState.AddModelError("Email", "This Email Is already Token");
                return View(model);
            }

            var userWithSameUserName = await _userManager.FindByNameAsync(model.UserName);


            if (userWithSameUserName != null && userWithSameUserName.Id != model.Id)
            {
                ModelState.AddModelError("UserName", "This UserName Is already Token");
                return View(model);
            }

            user.FullName = model.FullName;
            user.Email = model.Email;
            user.UserName =model.UserName;

            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            var roles = await _roleManager.Roles.ToListAsync();

            var viewModel = new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(role => new RoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
                return NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in model.Roles)
            {
                if (userRoles.Any(r => r == role.RoleName) && !role.IsSelected)
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);

                if (!userRoles.Any(r => r == role.RoleName) && role.IsSelected)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
