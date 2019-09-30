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
    public class DemandController : Controller
    {
        private readonly MNH_EcommerceContext _context;

        public DemandController(MNH_EcommerceContext context)
        {
            _context = context;
        }

        // GET: Demand
        public async Task<IActionResult> Index()
        {
            var mNH_EcommerceContext = _context.Demands.Include(d => d.PayWay).Include(d => d.User);
            return View(await mNH_EcommerceContext.ToListAsync());
        }

        // GET: Demand/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demand = await _context.Demands
                .Include(d => d.PayWay)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demand == null)
            {
                return NotFound();
            }

            return View(demand);
        }

        // GET: Demand/Create
        public IActionResult Create()
        {
            ViewData["PayWayId"] = new SelectList(_context.PayWays, "Id", "Description");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: Demand/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DemandDate,UserId,DeliveryDate,CEP,State,City,CompleteAddress,AddressNumber,PayWayId")] Demand demand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PayWayId"] = new SelectList(_context.PayWays, "Id", "Description", demand.PayWayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", demand.UserId);
            return View(demand);
        }

        // GET: Demand/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demand = await _context.Demands.FindAsync(id);
            if (demand == null)
            {
                return NotFound();
            }
            ViewData["PayWayId"] = new SelectList(_context.PayWays, "Id", "Description", demand.PayWayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", demand.UserId);
            return View(demand);
        }

        // POST: Demand/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DemandDate,UserId,DeliveryDate,CEP,State,City,CompleteAddress,AddressNumber,PayWayId")] Demand demand)
        {
            if (id != demand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemandExists(demand.Id))
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
            ViewData["PayWayId"] = new SelectList(_context.PayWays, "Id", "Description", demand.PayWayId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", demand.UserId);
            return View(demand);
        }

        // GET: Demand/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demand = await _context.Demands
                .Include(d => d.PayWay)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demand == null)
            {
                return NotFound();
            }

            return View(demand);
        }

        // POST: Demand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var demand = await _context.Demands.FindAsync(id);
            _context.Demands.Remove(demand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemandExists(int id)
        {
            return _context.Demands.Any(e => e.Id == id);
        }
    }
}
