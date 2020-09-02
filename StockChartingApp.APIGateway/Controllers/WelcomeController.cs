using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StockChartingApp.APIGateway.Controllers
{
    [ApiController]
    [Route("stockchartingapp")]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Welcome to Stock Charting App !!!";
        }
    }
}
