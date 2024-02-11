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
        public async Task<IActionResult> Get(int id)
        {
            var record = await _context.Records.FirstOrDefaultAsync(m => m.RecordId == id);
            if (id == 0)
                return Ok(record);
            if (record == null)
                return NotFound();
            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Record record)
        {
            if(record.RecordId == 0) 
                return BadRequest();
            _context.Add(record);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Record recordData)
        {
            if (recordData == null || recordData.RecordId == 0)
                return BadRequest();

            var record = await _context.Records.FindAsync(recordData.RecordId);
            if (record == null)
                return NotFound();
            record.RecordId = recordData.RecordId;
            record.RecordPictureUrl = recordData.RecordPictureUrl;
            record.AlbumName = recordData.AlbumName;
            record.ArtistName = recordData.ArtistName;
            record.ReleaseYear = recordData.ReleaseYear;
            record.AlbumSongs = recordData.AlbumSongs;
            record.MyRating = recordData.MyRating;
            record.WhatCollection = recordData.WhatCollection;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = _context.Records.FindAsync(id);
            if (record.Result == null)
                return NotFound(id);
            _context.Records.Remove(record.Result);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
