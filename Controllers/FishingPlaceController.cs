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
    [Authorize(Roles = "Administrator,User")]
    public class FishingPlaceController : Controller
    {
        private readonly FishingPlaceService _fishingPlaceService;

        public FishingPlaceController(FishingPlaceService fishingPlaceService)
        {
            _fishingPlaceService = fishingPlaceService;
        }
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Index(string searchString)
        {
            var fishingPlace = _fishingPlaceService.GetFishingPlace();
            if (!String.IsNullOrEmpty(searchString))
            {
                fishingPlace = _fishingPlaceService.GetFishingPlaceByCondition(s => s.FishingLocation.Contains(searchString)
                                                                          || s.FishingPlaceName.Contains(searchString));
            }
            return View(fishingPlace);
        }


        // GET: Fishing/Details/5
       
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishingPlace = _fishingPlaceService.GetFishingPlace().FirstOrDefault(m => m.ID == id);
            if (fishingPlace == null)
            {
                return NotFound();
            }

            return View(fishingPlace);
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
        public IActionResult Create([Bind("ID,FishingPlaceName,FishingLocation")] FishingPlace fishingPlace)
        {
            if (ModelState.IsValid)
            {
                _fishingPlaceService.AddFishingPlace(fishingPlace);
                _fishingPlaceService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(fishingPlace);
        }

        // GET: Fishing/Edit/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishingPlace = _fishingPlaceService.GetFishingPlace().FirstOrDefault(m => m.ID == id);
            if (fishingPlace == null)
            {
                return NotFound();
            }
            return View(fishingPlace);
        }

        // POST: Fishing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("ID,FishingPlaceName,FishingLocation")] FishingPlace fishingPlace)
        {
            if (id != fishingPlace.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _fishingPlaceService.UpdateFishingPlace(fishingPlace);
                    _fishingPlaceService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishingPlaceExists(fishingPlace.ID))
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
            return View(fishingPlace);
        }

        // GET: Fishing/Delete/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fishingPlace = _fishingPlaceService.GetFishingPlace().FirstOrDefault(m => m.ID == id);
            if (fishingPlace == null)
            {
                return NotFound();
            }

            return View(fishingPlace);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var fishingPlace = _fishingPlaceService.GetFishingPlaceByCondition(b => b.ID == id).FirstOrDefault();
            _fishingPlaceService.DeleteFishingPlace(fishingPlace);
            _fishingPlaceService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool FishingPlaceExists(Guid id)
        {
            return _fishingPlaceService.GetFishingPlace().Any(e => e.ID == id);
        }
    }
}