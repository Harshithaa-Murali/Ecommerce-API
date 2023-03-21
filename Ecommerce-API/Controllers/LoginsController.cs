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
    public class LoginsController : ControllerBase
    {
        private readonly ILoginService<LoginDetail> serviceObj;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(LoginsController));
        public LoginsController(ILoginService<LoginDetail> _serviceObj)
        {
           serviceObj = _serviceObj;
        }

        // GET: api/Logins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginDetail>>> GetLoginDetails()
        {
            _log4net.Info("Login List retrieved");
            return serviceObj.GetAll();
        }

        // GET: api/Logins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginDetail>> GetLoginDetail(int id)
        {
            var loginDetail = serviceObj.Get(id);
            if (loginDetail == null)
            {
                return NotFound();
            }
            _log4net.Info("Login details for"+id+" retrieved");
            return loginDetail;
        }
        [HttpGet("un/{un}")]
        public async Task<ActionResult<LoginDetail>> GetLoginDetail(string un)
        {
            var loginDetail = serviceObj.GetU(un);
            if (loginDetail == null)
            {
                return NotFound();
            }
            return loginDetail;
        }

        // PUT: api/Logins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginDetail(int id, LoginDetail loginDetail)
        {
            _log4net.Info("Login Details updated for user id" + id);
            serviceObj.UpdateLogin(id, loginDetail);
            return Ok();
        }

        // POST: api/Logins
        [HttpPost]
        public async Task<ActionResult<LoginDetail>> PostLoginDetail(LoginDetail loginDetail)
        {
            serviceObj.AddLogin(loginDetail);
            _log4net.Info("New login details added for user id" + loginDetail.Cid) ;
            return CreatedAtAction("GetLoginDetail", new { id = loginDetail.Cid }, loginDetail);
        }

        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginDetail(int id)
        {
            serviceObj.DeleteLogin(id);
            return Ok();
        }
    }
}
