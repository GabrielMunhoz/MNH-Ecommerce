using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MNH_Ecommerce.Domain.Entity;
using MNH_Ecommerce.Repository.Context;

namespace MNH_Ecommerce.MVC.Controllers
{
    public class ItemDemandController : Controller
    {
        private readonly MNH_EcommerceContext _context;

        public ItemDemandController(MNH_EcommerceContext context)
        {
            _context = context;
        }

        // GET: ItemDemand
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemDemands.ToListAsync());
        }

        // GET: ItemDemand/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemDemand = await _context.ItemDemands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemDemand == null)
            {
                return NotFound();
            }

            return View(itemDemand);
        }

        // GET: ItemDemand/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemDemand/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Quantity")] ItemDemand itemDemand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemDemand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemDemand);
        }

        // GET: ItemDemand/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemDemand = await _context.ItemDemands.FindAsync(id);
            if (itemDemand == null)
            {
                return NotFound();
            }
            return View(itemDemand);
        }

        // POST: ItemDemand/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Quantity")] ItemDemand itemDemand)
        {
            if (id != itemDemand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemDemand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemDemandExists(itemDemand.Id))
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
            return View(itemDemand);
        }

        // GET: ItemDemand/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemDemand = await _context.ItemDemands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemDemand == null)
            {
                return NotFound();
            }

            return View(itemDemand);
        }

        // POST: ItemDemand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemDemand = await _context.ItemDemands.FindAsync(id);
            _context.ItemDemands.Remove(itemDemand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemDemandExists(int id)
        {
            return _context.ItemDemands.Any(e => e.Id == id);
        }
    }
}
