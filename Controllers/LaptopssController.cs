using sell_laptops.LMS.Data;
using sell_laptops.LMS.Data.Services;
using sell_laptops.LMS.Data.Static;
using sell_laptops.LMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sell_laptops.LMS.Controllers
{
    [Authorize(Roles = UserRoles.Admin)] // V.97
    public class LaptopssController : Controller
    {
        private readonly ILaptopssService _Service;

        public LaptopssController(ILaptopssService Service)
        {
            _Service = Service;
        }



        // <summary>
        [AllowAnonymous] // V.96
        public async Task<IActionResult> Index()
        {
            var Data = await _Service.GetAll();
            return View(Data);
        }// End of GetAll </summary>

        [AllowAnonymous] // V.96
        public async Task<IActionResult> Filter(string searchString) 
        {
            var AllLaptopss = await _Service.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                var FilterResult = AllLaptopss.Where(n => n.Name.Contains(searchString) || n.LaptopCategory.ToString().Contains(searchString)).ToList(); // Search by name, and by LaptopCategory to sort. MSH
                if (FilterResult.Count != 0)
                {
                    return View("Index", FilterResult);
                }
                TempData["Error"] = "Hmm no result, check letter case OR Sort by use category name"; // Optmize Code [+if&TempData] MSH
            }
            return View("Index",AllLaptopss);
        } // End of Filter V.61

        // <summary> Get Laptop for CreateView
        public IActionResult Create()
        {
            return View();
        }
        // Post CreateLaptop
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ImageCode,Name,Description,Price,LaptopCategory")] Laptop Laptop)
        {
            if (!ModelState.IsValid)
            {
                return View(Laptop);
            }
           await _Service.Add(Laptop);
            return RedirectToAction(nameof(Index));

        }// End of Create Get&Post </summary>


        // <summary> Get Laptop for GetEditView + [used to get for delete also]
        public async Task<IActionResult> Edit(int id)
        {
            // <QA> lins insure data still in Db not just in UI _ Case1:
            var LaptopDetails = await _Service.GetByID(id);
            if(LaptopDetails == null ) return View ("NotFounded"); // </QA>

            return View(LaptopDetails);
        }
        // Post EditLaptop
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("ID,ImageCode,Name,Description,Price,LaptopCategory")] Laptop Laptop)
        {
            /*// <QA> lins insure data still in Db not just in UI _ Case2:
             var LaptopDetails = await _Service.GetByID(id);         // Error ocurred with QA lins Case2 | MSG_[Model tracked by other instance]
             if (LaptopDetails == null) return View("NotFounded");   // </QA> */   
            if (!ModelState.IsValid)
            {
                return View(Laptop);
            }
            //Edit or Update
            
            await _Service.Update(id,Laptop);
            return RedirectToAction(nameof(Index));

        }// End of Edit Get&Post </summary>


        // <summary> Get Laptop to DeletetView Using EditView
        // Post DeleteLaptop
        public async Task<IActionResult> Delete(int id)
        {
            // <QA> lins insure data still in Db not just in UI _ Case3:
            var LaptopDetails = await _Service.GetByID(id);
            if (LaptopDetails == null) return View ("NotFounded"); // </QA>

            await _Service.Delete(id);
            return RedirectToAction(nameof(Index));

        }//  End of Delete Post </summary>

    }
}
