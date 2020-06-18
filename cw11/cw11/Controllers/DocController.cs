using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw11.Controllers
{
    [Route("api/doc")]
    [ApiController]
    public class DocController : ControllerBase
    {
        private readonly DocDbContext _context;
        public DocController(DocDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_context.Doctors.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            return Ok(_context.Doctors.Where(e => e.IdDoctor == id).First());
        }

        [HttpPost("{id}")]
        public IActionResult UpdateDoctor(Doctor doc, int id)
        {
            var d = new Doctor
            {
                IdDoctor = id,
                FirstName = doc.FirstName,
                LastName = doc.LastName,
                Email = doc.Email
            };

            _context.Attach(d);
            _context.Entry(d).Property("FirstName").IsModified = true;
            _context.Entry(d).Property("LasttName").IsModified = true;
            _context.Entry(d).Property("Email").IsModified = true;
            _context.SaveChanges();

            return Ok(d);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {

            var s = _context.Doctors.Where(s => s.IdDoctor == id).First();
            _context.Doctors.Remove(s);
            _context.SaveChanges();

            return Ok("usunieto");
        }
    }
}
