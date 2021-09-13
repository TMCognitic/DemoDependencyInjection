using DemoDependencyInjection.Models;
using DemoDependencyInjection.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISingletonRepository _singletonRepository;
        private readonly IScopedRepository _scopedRepository;
        private readonly ITransientRepository _transientRepository;

        public HomeController(ISingletonRepository singletonRepository, 
                              IScopedRepository scopedRepository, 
                              ITransientRepository transientRepository)
        {
            _singletonRepository = singletonRepository;
            _scopedRepository = scopedRepository;
            _transientRepository = transientRepository;
        }

        public IActionResult Index()
        {
            ViewBag.SingletonHashCode = _singletonRepository.GetHashCode();
            ViewBag.ScopedHashCode = _scopedRepository.GetHashCode();
            ViewBag.TransientHashCode = _transientRepository.GetHashCode();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        #region Masqué pour des raisons de mise en page
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        #endregion
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

