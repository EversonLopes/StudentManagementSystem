using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementSystem.Models;
using StudentManagementSystem.Models.ViewModels;
using StudentManagementSystem.Services.Exceptions;
using System.Diagnostics;

namespace StudentManagementSystem.Controllers
{
    public class UsersController : Controller
    {

        private readonly UserService _userService;
        private readonly RoleService _roleService;

        public UsersController(UserService userService, RoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _userService.FindAllAsync();
            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            var roles = await _roleService.FindAllAsync();
            var viewModel = new UserFormViewModel { Roles = roles };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
            {
                var roles = await _roleService.FindAllAsync();
                var viewModel = new UserFormViewModel { User = user, Roles = roles };
                return View(viewModel);

            }
            await _userService.InsertAsync(user);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _userService.FindByIDAsync (id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _userService.FindByIDAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _userService.FindByIDAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            List<Role> roles = await _roleService.FindAllAsync();
            UserFormViewModel viewModel = new UserFormViewModel { User = obj, Roles = roles };
            return View(viewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                var roles = await _roleService.FindAllAsync();
                var viewModel = new UserFormViewModel { User=user, Roles = roles };
                return View(viewModel);
                
            }
            if (id != user.User_id)
            {
                return BadRequest();
            }

            try
            {
                await _userService.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
          
        }
        public IActionResult Error(string message) {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
