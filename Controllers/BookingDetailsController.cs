using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TaxiBookingAPI.Models;


namespace TaxiBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingDetailsController : ControllerBase
    {
        private readonly BookingDetailContext _context;

        public BookingDetailsController(BookingDetailContext context)
        {
            _context = context;
        }

        // GET: api/BookingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDetail>>> GetBookingDetails()
        {
            return await _context.BookingDetails.ToListAsync();
        }

        // GET: api/BookingDetails/5
        [HttpGet("{BookingDate }")]
        public async Task<ActionResult<BookingDetail>> GetBookingDetail(string BookingDate)
        {
            var BookingDetail = await _context.BookingDetails.FindAsync(BookingDate);

            if (BookingDetail == null)
            {
                return NotFound();
            }

            return BookingDetail;
        }

        // PUT: api/BookingDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{BookingDate}")]
        public async Task<IActionResult> PutBookingDetail(string BookingDate, BookingDetail BookingDetail)
        {
            if (BookingDate != BookingDetail.BookingDate)
            {
                return BadRequest();
            }

            _context.Entry(BookingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!BookingDetailExists(BookingDate)
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return NoContent();
        }

        // POST: api/BookingDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingDetail>> PostBookingDetail(BookingDetail BookingDetail)
        {
            _context.BookingDetails.Add(BookingDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookingDetail", new { Date = BookingDetail.BookingDate}, BookingDetail);
        }

        // DELETE: api/BookingDetails/5
        [HttpDelete("{BookingDate }")]
        public async Task<IActionResult> DeleteBookingDetail(string BookingDate)
        {
            var BookingDetail = await _context.BookingDetails.FindAsync(BookingDate);
            if (BookingDetail == null)
            {
                return NotFound();
            }

            _context.BookingDetails.Remove(BookingDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingDetailExists(string BookingDate)
        {
            return _context.BookingDetails.Any(e => e.BookingDate == BookingDate);
        }
    }
}
