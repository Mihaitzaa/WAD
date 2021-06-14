using FishingHunting.Models;
using FishingHunting.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishingHunting.Controllers
{
    
    public class FishingController : Controller
    {
        private readonly FishingService _fishingService;

        public FishingController(FishingService fishingService)
        {
            _fishingService = fishingService;
        }
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Index(string searchString)
        {
            var fishingItem = _fishingService.GetFishingItem();
            if (!String.IsNullOrEmpty(searchString))
            {
                fishingItem = _fishingService.GetFishingItemByCondition(s => s.FishingProductType.Contains(searchString) 
                                                                          || s.FishingProductName.Contains(searchString));
            }
            return View(fishingItem);
        }


        // GET: Fishing/Details/5
        
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishingitem = _fishingService.GetFishingItem().FirstOrDefault(m => m.ID == id);
            if (fishingitem == null)
            {
                return NotFound();
            }

            return View(fishingitem);
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
        public IActionResult Create([Bind("ID,FishingProductName,FishingProductType")] Fishing fishingItem)
        {
            if (ModelState.IsValid)
            {
                _fishingService.AddFishingItem(fishingItem);
                _fishingService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(fishingItem);
        }

        // GET: Fishing/Edit/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishingitem = _fishingService.GetFishingItem().FirstOrDefault(m => m.ID == id);
            if (fishingitem == null)
            {
                return NotFound();
            }
            return View(fishingitem);
        }

        // POST: Fishing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("ID,FishingProductName,FishingProductType")] Fishing fishingItem)
        {
            if (id != fishingItem.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _fishingService.UpdateFishingItem(fishingItem);
                    _fishingService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishingItemExists(fishingItem.ID))
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
            return View(fishingItem);
        }

        // GET: Fishing/Delete/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishingItem = _fishingService.GetFishingItem().FirstOrDefault(m => m.ID == id);
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
            var fishingitem = _fishingService.GetFishingItemByCondition(b => b.ID == id).FirstOrDefault();
            _fishingService.DeleteFishingItem(fishingitem);
            _fishingService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool FishingItemExists(Guid id)
        {
            return _fishingService.GetFishingItem().Any(e => e.ID == id);
        }
    }
}