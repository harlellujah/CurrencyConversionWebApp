using CurrencyConverter.Models.Conversion;
using CurrencyConverter.Models.Error;
using CurrencyConverter.ServiceLayer.CurrencyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ICurrencyService _currencyService;

        public HomeController(ILogger<HomeController> logger, ICurrencyService currencyService)
        {
            _logger = logger;
            this._currencyService = currencyService;
        }

        public IActionResult Index()
        {
            try
            {
                ConvertCurrencyModel model = new ConvertCurrencyModel();
                model.SessionId = Guid.NewGuid();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Index(ConvertCurrencyModel model)
        {
            try
            {
                _currencyService.Convert(model);

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
