using Microsoft.EntityFrameworkCore;
using OfferMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMicroservice.DBContext
{
    public class OfferContext : DbContext
    {
        public OfferContext(DbContextOptions<OfferContext> options) : base(options)
        {
        }
        public DbSet<Offer> Offers { get; set; }
    }
}