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
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService<Admin> serviceObj;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AdminsController));
        public AdminsController(IAdminService<Admin> _serviceObj)
        {
            serviceObj = _serviceObj;
        }

        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            _log4net.Info("Admin list retrieved");
            return serviceObj.GetAll();
        }
    }
}
