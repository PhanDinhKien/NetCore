using Bbk.Data.Repository;
using Bbk.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bbk.Web.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;

        private readonly IDistributedCache _distributedCache;

        private readonly IUserRepository _userRepository; 

        public HomeController(
            ILogger<HomeController> logger, 
            IDistributedCache distributedCache,
            IUserRepository userRepository
            )
        {
            _logger = logger;
            _distributedCache = distributedCache;
            _userRepository = userRepository; 
        }

        public async Task<IActionResult> Index()
        {
            var data = await _userRepository.GetByIdAsync(Guid.Parse("668316db-8418-47ec-9fb7-63febac8e3dd"));

            var dt = await _userRepository.FindAsync(x => x.FistName.Contains("kiên")); 

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
