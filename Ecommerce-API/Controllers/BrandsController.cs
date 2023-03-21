using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerce_API.Models;
using Ecommerce_API.Service;

namespace Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService<Brand> serviceObj;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(BrandsController));
        public BrandsController(IBrandService<Brand> _serviceObj)
        {
            serviceObj = _serviceObj;
        }
        // GET: api/Brands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            _log4net.Info("Brands List retrieved");
            return serviceObj.GetAll();
        }
    }
}
