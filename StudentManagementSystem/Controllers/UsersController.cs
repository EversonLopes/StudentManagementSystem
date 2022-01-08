﻿using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class UsersController : Controller
    {

        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            var list = _userService.FindAll();
            return View(list);
        }
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user) {
            _userService.Insert(user);
            return RedirectToAction(nameof(Index));
        }
    }
}