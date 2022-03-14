using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace TaxiBookingAPI.Models
{
    public class BookingDetailContext : DbContext

    {
        public BookingDetailContext(DbContextOptions<BookingDetailContext> options)
           : base(options)
        {
        }
        public DbSet<BookingDetail> BookingDetails { get; set; } = null!;

    }
}
