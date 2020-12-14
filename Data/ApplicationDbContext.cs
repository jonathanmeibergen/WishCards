using WishCards.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WishCards.Data
{
    #region datastorage
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WishCard> WishCards;
        public DbSet<Recipient> Recipients;
        public DbSet<WishCards.Models.Recipient> Recipient { get; set; }
    }

    #endregion
}
