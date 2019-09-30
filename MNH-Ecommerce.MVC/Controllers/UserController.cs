using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MNH_Ecommerce.Domain.Contrats;
using MNH_Ecommerce.Domain.Entity;
using MNH_Ecommerce.Repository.Context;
using MNH_Ecommerce.Repository.Repositories;

namespace MNH_Ecommerce.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _context;
        public static bool usuarioLogado = false;

        public UserController(IUserRepository context)
        {
            _context = context;
        }

        // GET: User
        public IActionResult Index()
        {
            return View(_context.GetAll());
        }

        public IActionResult Entrar()
        {
            if (usuarioLogado)
            {
                return RedirectToAction("Index", "User", new { area = "" });
            }
            return View();

        }

        public IActionResult Logar([Bind("Email,Password")] User user)
        {
            try
            {
                var returnedUser = _context.Login(user.Email, user.Password);

                if (returnedUser != null)
                {
                    usuarioLogado = true;

                    return RedirectToAction("Index", "User", new { area = "" });
                }
                return RedirectToAction("Create", "User", new { area = "" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Create", "User", new { area = "" });
            }
        }
        // GET: User/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context.GetAll().FirstOrDefault(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Email,Password,Name,LastName")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var user = _context.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Email,Password,Name,LastName")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context.GetAll().FirstOrDefault(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _context.GetById(id);
            _context.Delete(user);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.GetAll().Any(e => e.Id == id);
        }
    }
}
