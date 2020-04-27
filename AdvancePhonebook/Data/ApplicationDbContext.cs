using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AdvancePhonebook.Models;

namespace AdvancePhonebook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AdvancePhonebook.Models.Contacts> Contacts { get; set; }
        public DbSet<AdvancePhonebook.Models.Enterprises> Enterprises { get; set; }
        public DbSet<AdvancePhonebook.Models.Descriptions> Descriptions { get; set; }
    }
}