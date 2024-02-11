using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VinylAPI.Models;

namespace VinylAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VinylController : ControllerBase
    {
        private readonly VinylDatabaseContext _context;

        public VinylController(VinylDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Record>> Get()
        {
            return await _context.Records.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task
    }
}
