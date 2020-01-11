/*
  Author:    Joshua Lipio
  Date:      10/18/2019
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540 and Joshua Lipio - This work may not be copied for use in Academic Coursework.

  I, Joshua Lipio, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CS4540_PS2.Data;
using CS4540_PS2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace CS4540_PS2.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IdentityDB _id;

        public HomeController(SchoolContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IdentityDB id)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _id = id;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Professor()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Roles()
        {
            ViewBag.roleManager = _roleManager;
            ViewBag.userManager = _userManager;
            return View(_id);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeRole(string userName, string roleName, bool addRemove)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var role = await _roleManager.FindByNameAsync(roleName);
            //add user to role
            if (addRemove)
            {
                await _userManager.AddToRoleAsync(user, roleName);
                return new JsonResult(new { success = true });
            }
            //if removing user from role
            else
            {
                //if role being removed is admin
                if (roleName == "Admin")
                {
                    //check # of admins, dont allow change if only 1 admin
                    var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);
                    if (usersInRole.Count <= 1) { return BadRequest(); }
                    else { await _userManager.RemoveFromRoleAsync(user, role.Name); return new JsonResult(new { success = true }); }
                }
                //remove user from role
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
                    return new JsonResult(new { success = true });
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
