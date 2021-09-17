using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siscs.MongoDB.Api.Controllers
{
    [ApiController]
    public abstract class MainController<TController> : ControllerBase
    {
        private readonly ILogger<TController> _logger;
        public MainController(ILogger<TController> logger)
        {
            _logger = logger;
        }

    }
}
