using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCViewsDemo.Models.ViewModels;
using MVCViewsDemo.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCViewsDemo.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        DataManager _dataManager;

        public CarsController(CarsContext context)
        {
            _dataManager = new DataManager(context);
        }

        public IActionResult Index()
        {
            var viewModel = _dataManager.GetCars();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _dataManager.RemoveCar(id);
            return RedirectToAction(nameof(CarsController.Index));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            _dataManager.AddCar(viewModel);
            return Redirect(nameof(CarsController.Index));
        }

        public IActionResult Update(int id)
        {
            var viewModel = _dataManager.GetSingleCar(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(UpdateCarVM viewModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            _dataManager.UpdateCar(viewModel);
            return RedirectToAction(nameof(CarsController.Index));
        }
    }
}
