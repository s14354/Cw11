using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw11.Controllers
{
    [Route("api/med")]
    [ApiController]
    public class MedController : ControllerBase
    {
        private readonly DocDbContext _context;
        public MedController(DocDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMedicament()
        {
            return Ok(_context.Medicaments.ToList());
        }
    }
}
