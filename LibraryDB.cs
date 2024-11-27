using Microsoft.EntityFrameworkCore;
using Personal_Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Library
{
    public class LibraryDB : DbContext
    {
        public LibraryDB(DbContextOptions<LibraryDB> options) : base(options) { }

        public DbSet<Books> Books { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
    }
}
