using FishingHunting.Models;
using FishingHunting.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FishingHunting.Controllers
{
    
    public class HuntingController : Controller
    {
        private readonly HuntingService _huntingService;

        public HuntingController(HuntingService huntingService)
        {
            _huntingService = huntingService;
        }
        public IActionResult Index(string searchString)
        {
            var huntingitem = _huntingService.GetHuntingItem();
            if (!String.IsNullOrEmpty(searchString))
            {
                huntingitem = _huntingService.GetHuntingItemByCondition(s => s.HuntingProductType.Contains(searchString)
                                                                          || s.HuntingProductName.Contains(searchString));
            }
            return View(huntingitem);
        }

       
        // GET: Fishing/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huntingitem = _huntingService.GetHuntingItem().FirstOrDefault(m => m.ID == id);
            if (huntingitem == null)
            {
                return NotFound();
            }

            return View(huntingitem);
        }

        // GET: Fishing/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fishing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,HuntingProductName,HuntingProductType")] Hunting huntingitem)
        {
            if (ModelState.IsValid)
            {
                _huntingService.AddHuntingItem(huntingitem);
                _huntingService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(huntingitem);
        }

        // GET: Fishing/Edit/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huntingitem = _huntingService.GetHuntingItem().FirstOrDefault(m => m.ID == id);
            if (huntingitem == null)
            {
                return NotFound();
            }
            return View(huntingitem);
        }

        // POST: Fishing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("ID,HuntingProductName,HuntingProductType")] Hunting huntingitem)
        {
            if (id != huntingitem.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _huntingService.UpdateHuntingItem(huntingitem);
                    _huntingService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishingItemExists(huntingitem.ID))
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
            return View(huntingitem);
        }

        // GET: Fishing/Delete/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishingItem = _huntingService.GetHuntingItem().FirstOrDefault(m => m.ID == id);
            if (fishingItem == null)
            {
                return NotFound();
            }

            return View(fishingItem);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var huntingitem = _huntingService.GetHuntingItemByCondition(b => b.ID == id).FirstOrDefault();
            _huntingService.DeleteHuntingItem(huntingitem);
            _huntingService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool FishingItemExists(Guid id)
        {
            return _huntingService.GetHuntingItem().Any(e => e.ID == id);
        }
        
    }
}
